using UnityEngine;

public class BossStatusOriginally : MonoBehaviour
{
    //初期ステータス
    public int power = 15;
    public int Hp = 5000;
    public float speed = 2.5f;
    //ここまで

    int LoopCount = 1;

    BossFlag bossFlag;

    float waitTime = 0;
    
    public bool statusUpFlag = false;

    int count = 0;

    int EndressCount = 5;

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
        power = 25;

        Hp = 10000;

        speed = 3f;
    }

    //3体目のボスのステータス
    void StatusUp2()
    {
        power = 40;

        Hp = 400000;

        speed = 3.5f;
    }

    //4体目のボスのステータス
    void StatusUp3()
    {
        power = 50;


        Hp = 900000;

        speed = 4.5f;
    }

    //5体目のボスのステータス
    void StatusUp4()
    {
        power = 70;

        Hp = 1600000;

        speed = 5.5f;
    }

    //5体以降ボスのステータス
    void StatusUpEndress()
    {
        power += 20;

        Hp = EndressCount * EndressCount * 1000000;

        for(int i = 5; i < EndressCount; i++)
        {
            Hp *= 10;
        }   

        speed += 0.5f;

        EndressCount++;
    }
}
