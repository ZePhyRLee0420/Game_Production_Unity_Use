using UnityEngine;

public class BossAttackArea : MonoBehaviour
{
    GameObject bossManager;

    BossStatusOriginally originally;

    int damage;

    bool onceDamageFlag = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossManager = GameObject.Find("BossManager");
        originally = bossManager.GetComponent<BossStatusOriginally>();

        damage = originally.power;
    }

    private void OnEnable()
    {
        onceDamageFlag = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                if(onceDamageFlag)
                {
                    playerHealth.takeDamage(damage);
                    onceDamageFlag = false;
                }
            }
        }
    }

}
