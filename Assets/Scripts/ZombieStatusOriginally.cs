using UnityEngine;
using UnityEngine.AI;

//ゾンビのスポーン時に参照するステータスのスクリプト
public class ZombieStatusOriginally : MonoBehaviour
{
    public int power = 5;
    public int Hp = 10;
    public int exp = 1;
    public float speed = 1.4f;

    GameObject timerObject;

    Timer timer;
    int interval = 30;

    int count = 0;

    int b = 1;

    GameObject bossManager;

    BossFlag bossFlag;

    int hpUp = 5;

    int powerUp = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerObject = GameObject.Find("Timer");
        timer = timerObject.GetComponent<Timer>();

        bossManager = GameObject.Find("BossManager");
        bossFlag = bossManager.GetComponent<BossFlag>();
    }

    // Update is called once per frame
    void Update()
    {
        count = (int)timer.time / interval;

        if (count == b)
        {
            SpownStatusUp();
           // Debug.Log("power = " + power);
           // Debug.Log("Hp = " + Hp);
            b++;
        }

        exp = 1 + bossFlag.loop;

    }


    //15秒ごとにスポーン時のステータスを上げる
    void SpownStatusUp()
    {
        power += powerUp;

        Hp += hpUp;
    }
}
