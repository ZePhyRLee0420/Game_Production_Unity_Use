using UnityEngine;

public class resetSaveData : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        SaveData.instance.time = 0;
        SaveData.instance.zombieKillCount = 0;
        SaveData.instance.bossKillCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
