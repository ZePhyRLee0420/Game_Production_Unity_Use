using TMPro;
using UnityEngine;

public class resultZombie : MonoBehaviour
{
    TMP_Text resultText;

    int num = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resultText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveData.instance != null)
        {
            num = SaveData.instance.zombieKillCount;
        }

        resultText.text = "Zombie kill count : " + num;
    }
}
