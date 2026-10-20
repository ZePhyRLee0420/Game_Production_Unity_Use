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

    float attackTimeEnd = 2;

    ZombieStatus status;
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
    }

    // Update is called once per frame
    void Update()
    {
        float distance;

        distance = Vector3.Distance(transform.position, player.transform.position);

        if(attackFlag == false )
        {
            if(distance <= attackDistance )
            {
                attackFlag = true;
            }
        }

        else
        {
            attackTime += Time.deltaTime;

            if(attackTime >= attackTimeEnd )
            {
                attackFlag = false;
                attackTime = 0;
            }
        }

        if( attackFlag )
        {
            if (attackArea.activeSelf == false)
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
}
