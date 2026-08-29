using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;

    GameObject originalStatusObject;
    ZombieStatusOriginally originallyStatus;
    int EnterDamage;
    int StayDamage;

    ZombieStatus status;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        status = this.GetComponent<ZombieStatus>();
        originalStatusObject = GameObject.Find("ZombieStatusOriginally");
        originallyStatus = originalStatusObject.GetComponent<ZombieStatusOriginally>();
        EnterDamage = originallyStatus.power;
        StayDamage = originallyStatus.power;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.collider.GetComponent<PlayerHealth>();

            if(playerHealth != null)
            {
                playerHealth.takeDamage(EnterDamage);
                Debug.Log("EnterDamage = "+ EnterDamage);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.collider.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.takeDamage(StayDamage);
                Debug.Log("StayDamage = " + StayDamage);
            }
        }
    }
}
