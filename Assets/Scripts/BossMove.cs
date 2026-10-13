using UnityEngine;
using UnityEngine.AI;

public class BossMove : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;

    GameObject bossManager;

    BossStatusOriginally originally;

    int damage;

    GameObject attackArea;

    bool attackFlag = false;

    float attackDistance = 8;

    float attackTime = 0;

    float attackTimeEnd = 2;

    bool downFlag = false;

    float downTime = 0;

    float downTimeEnd = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");

        bossManager = GameObject.Find("BossManager");
        originally = bossManager.GetComponent<BossStatusOriginally>();

        damage = originally.power;

        attackArea = transform.Find("AttackArea").gameObject;

        //attackArea.SetActive(false);

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

        if(downFlag)
        {
            if (attackArea.activeSelf == true)
            {
                attackArea.SetActive(false);
            }
        }

        else if (attackFlag)
        {
            if(attackArea.activeSelf == false)
            {
                attackArea.SetActive(true);
            }
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
