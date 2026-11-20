using UnityEngine;

public class BossStatusOriginally : MonoBehaviour
{
    //初期ステータス
    public int power = 20;
    public int Hp = 500;
    public float speed = 2.5f;
    //ここまで

    int LoopCount = 1;

    BossFlag bossFlag;

    float waitTime = 0;
    
    public bool statusUpFlag = false;

    int count = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossFlag = GetComponent<BossFlag>();
    }

    // Update is called once per frame
    void Update()
    {
        if(statusUpFlag == true)
        {
            waitTime += Time.deltaTime;
        }

        if(statusUpFlag == true && waitTime >= 1f)
        {
            if(count == 0)
            {
                StatusUp1();
            }

            else if (count == 1)
            {
                StatusUp2();
            }

            else if (count == 2)
            {
                StatusUp3();
            }

            else if (count == 3)
            {
                StatusUp4();
            }

            else
            {
                StatusUpEndress();
            }



            statusUpFlag = false;
            waitTime = 0;
            count++;
        }
    }

    //2体目のボスのステータス
    void StatusUp1()
    {
        power = 50;

        Hp = 1000;

        speed = 2.5f;
    }

    //3体目のボスのステータス
    void StatusUp2()
    {
        power = 70;

        Hp = 1500;

        speed = 2.5f;
    }

    //4体目のボスのステータス
    void StatusUp3()
    {
        power = 90;

        Hp = 2000;

        speed = 2.5f;
    }

    //5体目のボスのステータス
    void StatusUp4()
    {
        power = 110;

        Hp = 2500;

        speed = 2.5f;
    }

    //5体以降ボスのステータス
    void StatusUpEndress()
    {
        power += 30;

        Hp += 500;

        speed = 2.5f;
    }
}
