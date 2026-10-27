using UnityEngine;

public class BossHealth : MonoBehaviour
{
    int maxHp;
    [SerializeField] int currentHp;


    GameObject bossManager;

    GameObject player;
    BossStatusOriginally originally;

    [SerializeField] GameObject damageUI;


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
        //Debug.Log("Boss HP: " + currentHp);

        if (currentHp < 0)
        {
            Die();
        }
    }

    public void TakeDamage(int value)
    {
        currentHp -= value;

        //ダメージUIの処理
        Vector3 DamageUIpos = transform.position;
        DamageUIpos.y += 8.5f; 

        GameObject obj = Instantiate(damageUI, DamageUIpos, Quaternion.identity);
        //obj.transform.SetParent(this.transform);

        Transform childTransform = obj.transform.Find("Text");
        GameObject child = childTransform.gameObject;

        if (child != null)
        {
            DamageUIController controller = child.GetComponent<DamageUIController>();
            controller.damage = value;
        }

        Destroy(obj, 1f);

    }

    void Die()
    {
        Destroy(gameObject);
    }

}
