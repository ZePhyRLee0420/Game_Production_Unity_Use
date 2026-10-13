using UnityEngine;

public class ZombieAttackArea : MonoBehaviour
{
    GameObject originalStatusObject;
    ZombieStatusOriginally originallyStatus;

    int damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalStatusObject = GameObject.Find("ZombieStatusOriginally");
        originallyStatus = originalStatusObject.GetComponent<ZombieStatusOriginally>();

        damage = originallyStatus.power;
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
                playerHealth.takeDamage(damage);
            }
        }
    }
}
