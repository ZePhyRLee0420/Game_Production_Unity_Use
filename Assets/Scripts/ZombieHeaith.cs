using UnityEngine;

public class ZombieHeaith : MonoBehaviour
{
    int maxHp;
    int currentHp;
    GameObject player;

    GameObject originalStatusObject;
    ZombieStatusOriginally originallyStatus;

    int exp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalStatusObject = GameObject.Find("ZombieStatusOriginally");
        originallyStatus = originalStatusObject.GetComponent<ZombieStatusOriginally>();

        maxHp = originallyStatus.Hp;
        currentHp = maxHp;

        exp = originallyStatus.exp;

        player = GameObject.Find("Player");
        Debug.Log("Health" + currentHp);

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
