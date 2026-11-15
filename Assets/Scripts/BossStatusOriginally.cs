using UnityEngine;

public class BossStatusOriginally : MonoBehaviour
{
    public int power = 30;
    public int Hp = 750;
    public float speed = 10f;

    int LoopCount = 1;

    int powerUp = 30;

    int HpUp = 750;

    BossFlag bossFlag;

    float waitTime = 0;
    
    public bool statusUpFlag = false;

    int count = 1;

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
            StatusUp();
            statusUpFlag = false;
            waitTime = 0;
        }
    }

    void StatusUp()
    {
        if(count <= 5)
        {
            power = powerUp * (count + 1) + 10 * (count - 1) ;
            Hp = 750 + HpUp * count;
        }

        else
        {
            power = powerUp * count + 20 * (count - 4 );
            Hp = 750 + HpUp * count + 500 * (count * 2 - 10);
            speed += 0.5f;
        }

        count++;
    }
}
