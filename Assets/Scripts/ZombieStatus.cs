using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

//ゾンビ一体一体が持つステータスのスクリプト
public class ZombieStatus : MonoBehaviour
{
    public int power;
    public int Hp;
    public int exp;
    public float speed;

    NavMeshAgent agent;

    GameObject originalStatusObject;
    ZombieStatusOriginally originally;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalStatusObject = GameObject.Find("ZombieStatusOriginally");
        originally = originalStatusObject.GetComponent<ZombieStatusOriginally>();

        power = originally.power;
        Hp = originally.Hp;
        exp = originally.exp;
        speed = originally.speed;

        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;

        Debug.Log("power = " + power);
        Debug.Log("Hp = " + Hp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
