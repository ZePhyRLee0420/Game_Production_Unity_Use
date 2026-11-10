using UnityEngine;
using UnityEngine.AI;

//ゾンビのスポーン時に参照するステータスのスクリプト
public class ZombieStatusOriginally : MonoBehaviour
{
    public int power = 2;
    public int Hp = 10;
    public float exp = 1f;
    public float speed = 2.5f;

    GameObject timerObject;

    Timer timer;
    int endressStatusUpinterval = 15;

    int count = 0;

    int b = 21;

    GameObject bossManager;

    BossFlag bossFlag;


    int c = 6;

    int intervalExp = 60;

    int count2 = 0;

    float currentTime = 0;
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
        count = (int)timer.time / endressStatusUpinterval;
        count2 = (int)timer.time / intervalExp;

        currentTime = timer.time;
       

        if(currentTime >= 30f &&  currentTime <= 60f)
        {
            SpownStatusUp1();
        }

        else if (currentTime >= 60f && currentTime <= 90f)
        {
            SpownStatusUp2();
        }

        else if (currentTime >= 90f && currentTime <= 120f)
        {
            SpownStatusUp3();
        }

        else if (currentTime >= 120f && currentTime <= 150f)
        {
            SpownStatusUp4();
        }

        else if (currentTime >= 150f && currentTime <= 180f)
        {
            SpownStatusUp5();
        }

        else if (currentTime >= 180f && currentTime <= 210f)
        {
            SpownStatusUp6();
        }

        else if (currentTime >= 210f && currentTime <= 240f)
        {
            SpownStatusUp7();
        }

        else if (currentTime >= 240f && currentTime <= 270f)
        {
            SpownStatusUp8();
        }

        else if (currentTime >= 270f && currentTime <= 300f)
        {
            SpownStatusUp9();
        }

        if(count == b)
        {

            SpownStatusUpEndress();

            b++;
        }

        if(count2 == c)
        {
            expUpEndress();
            c++;
        }

        /*
        Debug.Log("power = " + power);
        Debug.Log("Hp = " + Hp);
        Debug.Log("speed = " + speed);
        Debug.Log("exp = " + exp);
        */
    }


    //30～60秒のステータス
    void SpownStatusUp1()
    {
        power = 3;

        Hp = 20;

        speed = 2.5f;

        exp = 1f;
    }

    //60～90秒のステータス
    void SpownStatusUp2()
    {
        power = 5;

        Hp = 30;

        speed = 3f;

        exp = 2f;
    }

    //90～120秒のステータス
    void SpownStatusUp3()
    {
        power = 7;

        Hp = 40;

        speed = 3f;

        exp = 2f;
    }

    //120～150秒のステータス
    void SpownStatusUp4()
    {
        power = 10;

        Hp = 50;

        speed = 3.5f;

        exp = 4f;
    }

    //150～180秒のステータス
    void SpownStatusUp5()
    {
        power = 12;

        Hp = 60;

        speed = 3.5f;

        exp = 4f;
    }

    //180～210秒のステータス
    void SpownStatusUp6()
    {
        power = 15;

        Hp = 70;

        speed = 4f;

        exp = 5f;
    }

    //210～240秒のステータス
    void SpownStatusUp7()
    {
        power = 17;

        Hp = 80;

        speed = 4f;

        exp = 5f;
    }

    //240～270秒のステータス
    void SpownStatusUp8()
    {
        power = 20;

        Hp = 90;

        speed = 4.5f;

        exp = 6f;
    }

    //270～300秒のステータス
    void SpownStatusUp9()
    {
        power = 25;

        Hp = 100;

        speed = 4.5f;

        exp = 6f;
    }

    //300秒～ 15秒置きにHpと攻撃力強化
    void SpownStatusUpEndress()
    {
        power += 5;
        Hp += 7;
    }

    //300秒～　一分置きに経験値アップ
    void expUpEndress()
    {
        exp += 1;
    }
}
