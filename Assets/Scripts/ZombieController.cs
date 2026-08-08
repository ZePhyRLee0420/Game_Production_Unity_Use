using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    [SerializeField]int EnterDamage = 10;
    [SerializeField]int StayDamage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            PlayerHealthController playerHealth = collision.collider.GetComponent<PlayerHealthController>();

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
            PlayerHealthController playerHealth = collision.collider.GetComponent<PlayerHealthController>();

            if (playerHealth != null)
            {
                playerHealth.takeDamage(StayDamage);
                Debug.Log("StayDamage = " + StayDamage);
            }
        }
    }
}
