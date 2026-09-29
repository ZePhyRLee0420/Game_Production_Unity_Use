using UnityEngine;
using UnityEngine.AI;

public class BossMove : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;

    GameObject bossManager;

    BossStatusOriginally originally;

    int damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");

        bossManager = GameObject.Find("BossManager");
        originally = bossManager.GetComponent<BossStatusOriginally>();

        damage = originally.power;

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

            if (playerHealth != null)
            {
                playerHealth.takeDamage(damage);
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
                playerHealth.takeDamage(damage);
            }
        }
    }
}
