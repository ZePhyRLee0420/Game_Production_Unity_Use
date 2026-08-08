using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombatController : MonoBehaviour
{
    // Bomb throwing
    InputAction throwAction;
    public GameObject bombPrefab;
    public Transform throwPoint;
    public float throwForce = 15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        throwAction = InputSystem.actions.FindAction("Throw");
    }

    // Update is called once per frame
    void Update()
    {
        ThrowBomb();
    }
    void ThrowBomb()
    {
        if (throwAction.WasPressedThisFrame())
        {
            GameObject bomb = Instantiate(bombPrefab, throwPoint.position, Quaternion.identity);

            Rigidbody rb = bomb.GetComponent<Rigidbody>();

            rb.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);
        }

    }
}
