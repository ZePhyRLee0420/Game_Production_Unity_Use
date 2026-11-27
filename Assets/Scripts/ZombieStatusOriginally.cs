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

    int endressStatusUpCount = 0;

    float testTime = 0;

    int test = 1;

    int expupcount = 1;

    int z = 1;

    int ex = 1;
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

        /*
        test = (int)timer.time / 15;

        expupcount = (int)timer.time / 60;

        currentTime = timer.time;
       
        if(test == z)
        {
            statusUpTest();
            z++;
        }

        if(expupcount == ex)
        {
            expUpEndress();
            ex++;
        }
        */

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
        

    }


    //30～60秒のステータス
    void SpownStatusUp1()
    {
        power = 3;

        Hp = 20;

        speed = 3f;

        exp = 1f;
    }

    //60～90秒のステータス
    void SpownStatusUp2()
    {
        power = 5;

        Hp = 25;

        speed = 3f;

        exp = 2f;
    }

    //90～120秒のステータス
    void SpownStatusUp3()
    {
        power = 6;

        Hp = 30;

        speed = 3.25f;

        exp = 2f;
    }

    //120～150秒のステータス
    void SpownStatusUp4()
    {
        power = 9;

        Hp = 50;

        speed = 3.25f;

        exp = 3f;
    }

    //150～180秒のステータス
    void SpownStatusUp5()
    {
        power = 14;

        Hp = 60;

        speed = 3.5f;

        exp = 3f;
    }

    //180～210秒のステータス
    void SpownStatusUp6()
    {
        power = 19;

        Hp = 80;

        speed = 3.5f;

        exp = 4f;
    }

    //210～240秒のステータス
    void SpownStatusUp7()
    {
        power = 24;

        Hp = 90;

        speed = 3.75f;

        exp = 4f;
    }

    //240～270秒のステータス
    void SpownStatusUp8()
    {
        power = 30;

        Hp = 110;

        speed = 3.75f;

        exp = 5f;
    }

    //270～300秒のステータス
    void SpownStatusUp9()
    {
        power = 35;

        Hp = 110;

        speed = 4f;

        exp = 5f;
    }

    //300秒～ 15秒置きにHpと攻撃力強化
    void SpownStatusUpEndress()
    {
        power +=endressStatusUpCount * 6;
        Hp +=endressStatusUpCount * 50;
        speed += 0.2f;

        endressStatusUpCount++;
    }

    //300秒～　一分置きに経験値アップ
    void expUpEndress()
    {
        exp += 0.5f;
    }

    /*
    void statusUpTest()
    {
        Hp += 5;

        power += 1;
    }
    */
}
