using UnityEngine;

public class ZombieHeaith : MonoBehaviour
{
    int maxHp;
    int currentHp;
    GameObject player;

    GameObject originalStatusObject;
    ZombieStatusOriginally originallyStatus;

    [SerializeField] GameObject damageUI;

    float exp;

    ZombieController controller;

    bool DieFlag = false;

    float DieTime = 0;
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

        controller = GetComponent<ZombieController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp <= 0 && DieFlag == false)
        {
            Die();
        }

        if(DieFlag == true)
        {
            DieTime += Time.deltaTime;

            if(DieTime >= 0.5f)
            {
                Destroy(gameObject);
            }
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

        if(currentHp > 0)
        {
            Vector3 force = new Vector3(0f, 5f, 0);
            Vector3 random = new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3));
            force += random;

            controller.LaunchUpward(force);
        }

    }

    void Die()
    {
        DieFlag = true;

        PlayerEXP playerEXP = player.GetComponent<PlayerEXP>();

        if (playerEXP != null)
        {
            playerEXP.GainEXP(exp);
        }

        SaveData.instance.zombieKillCount++;

        Vector3 force = new Vector3(0, 20, 0);
        Vector3 random = new Vector3(Random.Range(10,10),0, Random.Range(10, 10));
        force += random;

        controller.LaunchUpward(force);

    }
}
