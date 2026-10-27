using UnityEngine;

public class ZombieHeaith : MonoBehaviour
{
    int maxHp;
    int currentHp;
    GameObject player;

    GameObject originalStatusObject;
    ZombieStatusOriginally originallyStatus;

    GameObject bossManager;

    BossFlag bossFlagScript;

    [SerializeField] GameObject damageUI;

    float exp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalStatusObject = GameObject.Find("ZombieStatusOriginally");
        originallyStatus = originalStatusObject.GetComponent<ZombieStatusOriginally>();

        maxHp = originallyStatus.Hp;
        currentHp = maxHp;

        exp = originallyStatus.exp;

        player = GameObject.Find("Player");
        //Debug.Log("Health" + currentHp);

        bossManager = GameObject.Find("BossManager");
        bossFlagScript = bossManager.GetComponent<BossFlag>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp <= 0)
        {
            Die();
        }

        else if(bossFlagScript.bossFlag == true)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int value)
    {
        currentHp -= value;

        //ダメージUIの処理
        Vector3 DamageUIpos = transform.position;
        DamageUIpos += transform.forward * 2f;

        GameObject obj = Instantiate(damageUI, DamageUIpos, Quaternion.identity );
        //obj.transform.SetParent(this.transform);

        Transform childTransform = obj.transform.Find("Text");
        GameObject child = childTransform.gameObject;

        if(child != null)
        {
            DamageUIController controller = child.GetComponent<DamageUIController>();
            controller.damage = value;
        }

        Destroy(obj,1f);

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
