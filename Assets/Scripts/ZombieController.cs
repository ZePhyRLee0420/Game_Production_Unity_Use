using UnityEngine;
using UnityEngine.AI;

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

    float attackStartUpTime = 0.7f;

    float attackAreaOnTimeEnd = 1f;
    float attackTimeEnd = 1.3f;

    ZombieStatus status;

    Animator m_animator;

    float attackAngle = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        status = this.GetComponent<ZombieStatus>();
        originalStatusObject = GameObject.Find("ZombieStatusOriginally");
        originallyStatus = originalStatusObject.GetComponent<ZombieStatusOriginally>();

        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");

        agent.speed = originallyStatus.speed;
        
        attackArea = transform.Find("AttackArea").gameObject;

        attackArea.SetActive(false);

        m_animator = GetComponent<Animator>();
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

        if ( attackFlag )
        {
            if (attackArea.activeSelf == false && attackTime >= attackStartUpTime  && attackTime <= attackAreaOnTimeEnd)
            {
                attackArea.SetActive(true);
            }

            if (attackArea.activeSelf == true && attackTime > attackAreaOnTimeEnd)
            {
                attackArea.SetActive(false);
            }
            agent.isStopped = true;
        }

        else
        {
            if (attackArea.activeSelf == true)
            {
                attackArea.SetActive(false);
            }

            agent.isStopped = false;
            agent.destination = player.transform.position;
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
}
