using UnityEngine;

public class CameraPointController : MonoBehaviour
{
    public Transform player;
    public float height = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        transform.position = player.position + Vector3.up * height;
    }
}
