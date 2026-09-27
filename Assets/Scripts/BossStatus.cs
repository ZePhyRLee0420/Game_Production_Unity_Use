using UnityEngine;

public class BossStatus : MonoBehaviour
{
    public int power;
    public int Hp;
    public int exp;
    public float speed;

    GameObject bossManager;
    BossStatusOriginally originally;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossManager = GameObject.Find("BossManager");
        originally = bossManager.GetComponent<BossStatusOriginally>();

        power = originally.power;
        Hp = originally.Hp;
        exp = originally.exp;
        speed = originally.speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
