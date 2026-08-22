using UnityEngine;

public class ZombieHeaith : MonoBehaviour
{
    [SerializeField] int maxHp = 10;
    int currentHp;
    GameObject player;

    int exp = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHp;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int value)
    {
        currentHp -= value;
    }

    void Die()
    {
        PlayerEXP playerEXP = player.GetComponent<PlayerEXP>();

        if (playerEXP != null)
        {
            playerEXP.GainEXP(exp);
        }

        Destroy(gameObject);
    }
}
