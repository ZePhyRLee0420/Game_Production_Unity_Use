using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

public class BossMove : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;

    GameObject bossManager;

    BossStatusOriginally originally;

    int damage;

    float walkSpeed;

    GameObject attackArea;

    bool attackFlag = false;

    float attackDistance = 7f;

    float attackTime = 0;

    float attackTimeEnd = 1.725f;

    bool downFlag = false;

    float downTime = 0;

    float downTimeEnd = 2f;

    float attackStartUpTime = 1.275f;

    float attackAreaSetactiveTimeEnd = 1.375f;

    float attackAngle = 20f;

    Animator m_animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");

        bossManager = GameObject.Find("BossManager");
        originally = bossManager.GetComponent<BossStatusOriginally>();

        damage = originally.power;
        walkSpeed = originally.speed;

        agent.speed = walkSpeed;

        attackArea = transform.Find("AttackArea").gameObject;

        m_animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float distance;

        distance = Vector3.Distance(transform.position, player.transform.position);

        //ボスの行動を決める
        if (downFlag)
        {
            downTime += Time.deltaTime;

            Debug.Log("Down");

            attackFlag = false;
            attackTime = 0;

            if(downTime >= downTimeEnd)
            {
                downFlag = false;
                downTime = 0;
            }
        }

        else if (attackFlag == false && downFlag == false && distance <= attackDistance && PlayerForward() == true)
        {
            attackFlag = true;
        }

        else if (attackFlag == true && downFlag == false)
        {
            attackTime += Time.deltaTime;

            if(attackTime >= attackTimeEnd)
            {
                attackFlag = false;
                attackTime = 0;
            }
        }

        m_animator.SetBool("IsAttacking", attackFlag);

        //ボスが行動を行う
        if(downFlag == true)
        {
            if (attackArea.activeSelf == true)
            {
                attackArea.SetActive(false);
            }

            agent.ResetPath();
            agent.isStopped = true;
        }

        else if (attackFlag == true)
        {
            if(attackTime >= 0.1f && attackTime <= attackStartUpTime)
            {
                Vector3 direction = player.transform.position - transform.position;
                float rotationSpeed = 90f;

                // Y軸（高さ）を0にして水平方向のベクトルのみにする
                direction.y = 0;

                if (direction != Vector3.zero)
                {
                    // その方向を向く回転を計算して適用
                    UnityEngine.Quaternion targetRotation = UnityEngine.Quaternion.LookRotation(direction);
                    transform.rotation = UnityEngine.Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                }
            }

            /*
            if (attackTime >= 1.3f && attackTime <= attackStartUpTime - 0.3f && rotateFlag == true)
            {
                this.transform.Rotate(0f, -360f * Time.deltaTime, 0f);
                //rotateFlag = false;
            }
            */
            if (attackTime >= attackStartUpTime && attackTime <= attackAreaSetactiveTimeEnd)
            {
                if(attackArea.activeSelf == false)
                {
                    attackArea.SetActive(true);
                }
            }

            else if(attackTime > attackAreaSetactiveTimeEnd )
            {
                if (attackArea.activeSelf == true)
                {
                    attackArea.SetActive(false);
                }
            }
            agent.ResetPath();
            agent.isStopped = true;
            //Debug.Log("IsAttacking");
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

    public void TakeDown()
    {
        if(attackFlag == true)
        {
            //downFlag = true;
        }
    }

    bool PlayerForward()
    {
        Vector3 playerPosition = player.transform.position;
        playerPosition.y = transform.position.y;

        Vector3 direction = playerPosition - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);

        if(angle < attackAngle)
        {
            return true;
        }

        return false;
    }
}
