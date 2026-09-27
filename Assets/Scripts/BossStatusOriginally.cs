using UnityEngine;

public class BossStatusOriginally : MonoBehaviour
{
    public int power = 10;
    public int Hp = 100;
    public int exp = 10;
    public float speed = 2.1f;

    int LoopCount = 1;

    BossFlag bossFlag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossFlag = GetComponent<BossFlag>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bossFlag.loop == LoopCount)
        {
            StatusUp();
            LoopCount++;
        }
    }

    void StatusUp()
    {
        power = 10 * (bossFlag.loop + bossFlag.loop);
        Hp += 100;
        exp += 10;
    }
}
