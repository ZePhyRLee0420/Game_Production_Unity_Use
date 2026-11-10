using UnityEngine;
using System;                    // Array.Sort用
using System.Collections.Generic; // List<T>用
using System.Linq;               // OrderBy, Where, Select用

public class ZombieSpownerManager : MonoBehaviour
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

    int zombieCountMax = 500;

    GameObject ZombieCountObject;

    ZombieCount zombieCountScript;

    GameObject[] spownerobjects;

    float[] distances;
    int maxSpowner = 5;

    int spownerUpInterval = 60;

    int c = 0;

    int d = 1;

    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");

        timerObject = GameObject.Find("Timer");
        timer = timerObject.GetComponent<Timer>();

        bossManager = GameObject.Find("BossManager");
        bossFlagScript = bossManager.GetComponent<BossFlag>();

        ZombieCountObject = GameObject.Find("ZombieCounter");

        zombieCountScript = ZombieCountObject.GetComponent<ZombieCount>();

        spownerobjects = GameObject.FindGameObjectsWithTag("ZombieSpowner");

        int spownerNum = spownerobjects.Length;

        distances = new float[spownerNum];

    }

    // Update is called once per frame
    void Update()
    {
        var SpownerList = new List<(GameObject obj, float num)>();

        for(int i = 0;  i < spownerobjects.Length; i++)
        {
            distances[i] = Vector3.Distance(player.transform.position, spownerobjects[i].transform.position);
            SpownerList.Add((spownerobjects[i], distances[i]));
        }

        var sorted = SpownerList.OrderBy(x => x.num).ToList();

        zombieCount = zombieCountScript.count;

        a = (int)timer.time / interval;
        c = (int)timer.time / spownerUpInterval;

        if(c == d)
        {
            if(d < spownerobjects.Length)
            {
                maxSpowner++;
            }
            d++;
        }

        if (a == b)
        {
            for (int i = 0; i < maxSpowner; i++)
            {
                if (zombieCount < zombieCountMax)
                {
                    var spownpoint = sorted[i];

                    Instantiate(zombie, spownpoint.obj.transform.position, spownpoint.obj.transform.rotation);
                }
            }

            b++;
        }

        SpownerList.RemoveAll(x => x.num >= 0 );
        sorted.RemoveAll(x => x.num >= 0);

    }
}
