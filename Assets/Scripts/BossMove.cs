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

    float attackDistance = 9f;

    float attackTime = 0;

    float attackTimeEnd = 3f;

    bool downFlag = false;

    float downTime = 0;

    float downTimeEnd = 2f;

    float attackStartUpTime = 1f;

    float attackAngle = 30f;


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
            if(attackArea.activeSelf == false && attackTime >= attackStartUpTime)
            {
                attackArea.SetActive(true);
            }

            agent.ResetPath();
            agent.isStopped = true;
            Debug.Log("IsAttacking");
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
            downFlag = true;
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
