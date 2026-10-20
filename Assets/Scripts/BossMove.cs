using UnityEngine;
using UnityEngine.AI;

public class BossMove : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;

    GameObject bossManager;

    BossStatusOriginally originally;

    int damage;

    float speed;

    GameObject attackArea;

    bool attackFlag = false;

    float attackDistance = 8f;

    float attackTime = 0;

    float attackTimeEnd = 3f;

    bool downFlag = false;

    float downTime = 0;

    float downTimeEnd = 5f;

    float attackStartUpTime = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");

        bossManager = GameObject.Find("BossManager");
        originally = bossManager.GetComponent<BossStatusOriginally>();

        damage = originally.power;
        speed = originally.speed;

        agent.speed = speed;

        attackArea = transform.Find("AttackArea").gameObject;


    }

    // Update is called once per frame
    void Update()
    {
        float distance;

        distance = Vector3.Distance(transform.position, player.transform.position);

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

        else if (attackFlag == false && downFlag == false)
        {
            if (distance <= attackDistance)
            {
                attackFlag = true;
            }
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

        if(downFlag == true)
        {
            if (attackArea.activeSelf == true)
            {
                attackArea.SetActive(false);
            }
        }

        else if (attackFlag == true)
        {
            if(attackArea.activeSelf == false && attackTime >= attackStartUpTime)
            {
                attackArea.SetActive(true);
            }

            Debug.Log("IsAttacking");
        }

        else
        {
            if (attackArea.activeSelf == true)
            {
                attackArea.SetActive(false);
            }

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
}
