using System;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieSpownerController : MonoBehaviour
{
    [SerializeField] GameObject zombie;

    [SerializeField] GameObject timerObject;

    Timer timer;

    int interval = 2;

    int a = 0;

    int b = 1;

    GameObject bossManager;

    BossFlag bossFlagScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = timerObject.GetComponent<Timer>();

        bossManager = GameObject.Find("BossManager");
        bossFlagScript = bossManager.GetComponent<BossFlag>();
    }

    // Update is called once per frame
    void Update()
    {
        a = (int)timer.time / interval;

        if (a == b)
        {
            if(bossFlagScript.bossFlag == false)
            {
                Instantiate(zombie);
            }
            b++;
        }
    }
}
