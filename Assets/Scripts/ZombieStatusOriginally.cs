using UnityEngine;
using UnityEngine.AI;

//ゾンビのスポーン時に参照するステータスのスクリプト
public class ZombieStatusOriginally : MonoBehaviour
{
    public int power = 1;
    public int Hp = 10;
    public int exp = 1;
    public float speed = 1.4f;

    GameObject timerObject;

    Timer timer;
    int interval = 15;

    int count = 0;

    int b = 1;

    int a = 0;

    int hpUp = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerObject = GameObject.Find("Timer");
        timer = timerObject.GetComponent<Timer>();
        a = power;
    }

    // Update is called once per frame
    void Update()
    {
        count = (int)timer.time / interval;

        if (count == b)
        {
            SpownStatusUp();
            //Debug.Log("power = " + power);
            //Debug.Log("Hp = " + Hp);
            b++;
        }

    }


    //15秒ごとにスポーン時のステータスを上げる
    void SpownStatusUp()
    {
        a++;

        power = a * a;

        Hp *= hpUp;
    }
}
