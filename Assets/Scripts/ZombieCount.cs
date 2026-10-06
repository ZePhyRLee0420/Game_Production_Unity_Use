using UnityEngine;

public class ZombieCount : MonoBehaviour
{
    GameObject[] objects;
    public int count;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        objects = GameObject.FindGameObjectsWithTag("Enemy");
        count = objects.Length;
        //Debug.Log(count);
    }
}
