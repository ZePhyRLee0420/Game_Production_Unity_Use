using System;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ZombieSpownerController : MonoBehaviour
{
    [SerializeField] GameObject zombie;

    [SerializeField] GameObject timerObject;

    Timer timer;

    int interval = 1;

    int a = 0;

    int b = 1;

    GameObject bossManager;

    BossFlag bossFlagScript;

    int zombieCount = 0;

    GameObject ZombieCountObject;

    ZombieCount zombieCountScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerObject = GameObject.Find("Timer");
        timer = timerObject.GetComponent<Timer>();

        bossManager = GameObject.Find("BossManager");
        bossFlagScript = bossManager.GetComponent<BossFlag>();

        ZombieCountObject = GameObject.Find("ZombieCounter");

        zombieCountScript = ZombieCountObject.GetComponent<ZombieCount>();
    }

    // Update is called once per frame
    void Update()
    {
        zombieCount = zombieCountScript.count;

        a = (int)timer.time / interval;

        if (a == b)
        {
            if(bossFlagScript.bossFlag == false)
            {
                if (zombieCount < 300)
                {
                    Instantiate(zombie, transform.position, transform.rotation);
                }
            }
            b++;
        }
    }
}
