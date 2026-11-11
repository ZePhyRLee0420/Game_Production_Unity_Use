using UnityEngine;

public class BossStatusOriginally : MonoBehaviour
{
    public int power = 50;
    public int Hp = 500;
    public float speed = 6f;

    int LoopCount = 1;

    int powerUp = 50;

    int HpUp = 500;

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
        power = powerUp * (count + count);
        Hp += HpUp;

        count++;
    }
}
