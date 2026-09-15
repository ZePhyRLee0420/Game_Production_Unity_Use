using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    TMP_Text TimeText;
    [SerializeField]GameObject timerObject;
    Timer timer;

    int TimeInt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TimeText = GetComponent<TMP_Text>();
        TimeText.text = "Time:0";
        timer = timerObject.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeInt = (int)timer.time;

        TimeText.text = "Time:" + TimeInt.ToString();
    }
}
