using UnityEngine;

public class BossFlag : MonoBehaviour
{
    public bool bossFlag = false;
    public int loop = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss");

        if (bosses.Length > 0)
        {
            bossFlag = true;
        }

        else if(bossFlag == true && bosses.Length == 0)
        {
            bossFlag = false;
            loop++;
        }
    }
}
