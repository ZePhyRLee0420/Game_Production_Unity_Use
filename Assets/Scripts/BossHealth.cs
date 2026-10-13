using UnityEngine;

public class BossHealth : MonoBehaviour
{
    int maxHp;
    [SerializeField]int currentHp;


    GameObject bossManager;

    GameObject player;
    BossStatusOriginally originally;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossManager = GameObject.Find("BossManager");
        originally = bossManager.GetComponent<BossStatusOriginally>();

        maxHp = originally.Hp;
        currentHp = maxHp;

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHp < 0)
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
        Destroy(gameObject);
    }
}
