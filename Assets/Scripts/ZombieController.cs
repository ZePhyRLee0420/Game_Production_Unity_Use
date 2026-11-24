using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class ZombieController : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;

    GameObject originalStatusObject;
    ZombieStatusOriginally originallyStatus;

    GameObject attackArea;

    bool attackFlag = false;

    float attackDistance = 3;

    float attackTime = 0;

    float attackStartUpTime = 0.35f;

    float attackAreaOnTimeEnd = 5f;
    float attackTimeEnd = 0.65f;

    ZombieStatus status;

    Animator m_animator;

    float attackAngle = 30f;

    Rigidbody rb;

    bool isLaunched;

    ZombieHeaith zombieHeaith;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        status = this.GetComponent<ZombieStatus>();
        originalStatusObject = GameObject.Find("ZombieStatusOriginally");
        originallyStatus = originalStatusObject.GetComponent<ZombieStatusOriginally>();

        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");

        agent.speed = originallyStatus.speed * Random.Range(0.5f, 1.2f);
        
        attackArea = transform.Find("AttackArea").gameObject;

        attackArea.SetActive(false);

        m_animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

        isLaunched = false;

        float randomTime = Random.Range(0f,1f);
        
        m_animator.Play("walk", 0, randomTime);

        m_animator.speed = Random.Range(0.9f, 1.1f);

        zombieHeaith = GetComponent<ZombieHeaith>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance;

        distance = Vector3.Distance(transform.position, player.transform.position);

        if(attackFlag == false )
        {
            if(distance <= attackDistance && PlayerForward() == true)
            {
                attackFlag = true;
                m_animator.Play("Attack", 0, 0f);
            }
        }

        else
        {
            attackTime += Time.deltaTime;

            if(attackTime >= attackTimeEnd)
            {
                attackFlag = false;
                attackTime = 0;
            }
        }

        m_animator.SetBool("IsAttacking", attackFlag);

        if(agent.enabled == false)
        {
            if(attackArea.activeSelf == true)
            {
                attackArea.SetActive(true);
            }
        }

        else if ( attackFlag && zombieHeaith.DieFlag == false)
        {
            if (attackArea.activeSelf == false && attackTime >= attackStartUpTime  && attackTime <= attackAreaOnTimeEnd)
            {
                attackArea.SetActive(true);
            }

            if (attackArea.activeSelf == true && attackTime > attackAreaOnTimeEnd)
            {
                attackArea.SetActive(false);
            }
            if (agent.enabled)
            {
                agent.isStopped = true;
            }
        }

        else if(zombieHeaith.DieFlag == false)
        {
            if (attackArea.activeSelf == true)
            {
                attackArea.SetActive(false);
            }

            if(agent.enabled)
            {
                agent.isStopped = false;
                agent.destination = player.transform.position;  
            }
        }
    }

    bool PlayerForward()
    {
        Vector3 playerPosition = player.transform.position;
        playerPosition.y = transform.position.y;

        Vector3 direction = playerPosition - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);

        if (angle < attackAngle)
        {
            return true;
        }

        return false;
    }

    // 外部（攻撃判定など）からこのメソッドを呼び出して飛ばす
    public void LaunchUpward(Vector3 force)
    {
        if (isLaunched) return;
        StartCoroutine(LaunchRoutine(force));
    }

    private IEnumerator LaunchRoutine(Vector3 force)
    {
        isLaunched = true;

        // 1. NavMeshAgentを無効化し、物理演算を有効にする
        agent.enabled = false;
        rb.isKinematic = false;

        // 2. 上方向（＋任意の方向）へ瞬間的な力を加える
        rb.AddForce(force, ForceMode.Impulse);

        // 3. 地面から離れるまで少し待つ
        yield return new WaitForSeconds(0.2f);

        // 4. 着地するまで待機（速度がほぼ0になるか、接地判定を取る）
        while (!IsGrounded() || rb.linearVelocity.y > 0.1f)
        {
            rb.AddForce(Vector3.up * -1f * 60f, ForceMode.Force);
            yield return null;
        }

        // 5. 物理演算を戻し、NavMeshAgentを再有効化する
        agent.enabled = true;
        rb.isKinematic = true;

        // 着地点がNavMeshから少しずれていた場合に備えて補正する
        if (NavMesh.SamplePosition(transform.position, out NavMeshHit hit, 2.0f, NavMesh.AllAreas))
        {
            agent.Warp(hit.position);
        }

        isLaunched = false;
    }

    // 簡易的な接地判定（足元にRayを飛ばす）
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, 0.3f);
    }
}

