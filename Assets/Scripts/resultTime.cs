using TMPro;
using UnityEngine;

public class resultTime : MonoBehaviour
{
    TMP_Text TimeText;

    int num = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TimeText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SaveData.instance != null)
        {
            num = (int)SaveData.instance.time;
        }

        TimeText.text = "Survival Time\n" + num;
    }
}
