using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Bomb throwing
    public GameObject bombPrefab;
    public Transform throwPoint;
    public float throwForce = 15f;

    PlayerInputHandler inputHandler;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputHandler = GetComponent<PlayerInputHandler>();

        inputHandler.OnThrow += ThrowBomb;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ThrowBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, throwPoint.position, Quaternion.identity);

        Rigidbody rb = bomb.GetComponent<Rigidbody>();

        rb.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);
    }
    void OnDestroy()
    {
        if (inputHandler != null)
        {
            inputHandler.OnThrow -= ThrowBomb;
        }
    }
}
