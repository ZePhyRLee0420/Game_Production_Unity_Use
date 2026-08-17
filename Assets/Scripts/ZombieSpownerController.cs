using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieSpownerController : MonoBehaviour
{
    [SerializeField] GameObject zombie;
    float time;
    [SerializeField]float interval = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= interval)
        {
            Instantiate(zombie);
            time = 0;
        }
    }
}
