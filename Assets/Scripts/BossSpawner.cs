using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject Boss;

    [SerializeField] GameObject timerObject;

    Timer timer;

    [SerializeField]int interval = 60;

    int a = 0;

    int b = 1;

    GameObject BossManager;

    BossStatusOriginally bossStatusOriginally;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        timerObject = GameObject.Find("Timer");
        timer = timerObject.GetComponent<Timer>();

        BossManager = GameObject.Find("BossManager");
        bossStatusOriginally = BossManager.GetComponent<BossStatusOriginally>();
    }

    // Update is called once per frame
    void Update()
    {
        a = (int)timer.time / interval;

        if(a == b)
        {
            Instantiate(Boss, transform.position, transform.rotation);
            bossStatusOriginally.statusUpFlag = true;
            b++;
        }
    }
}
