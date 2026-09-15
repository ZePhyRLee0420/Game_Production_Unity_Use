using UnityEngine;

public class BossSpowner : MonoBehaviour
{
    [SerializeField] GameObject Boss;

    [SerializeField] GameObject timerObject;

    Timer timer;

    int interval = 10;

    int a = 0;

    int b = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = timerObject.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        a = (int)timer.time / interval;

        if(a == b)
        {
            Instantiate(Boss);
            b++;
        }
    }
}
