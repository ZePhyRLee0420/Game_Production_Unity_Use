using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Bomb throwing
    public GameObject bombPrefab;
    public Transform throwPoint;
    public float throwForce = 15f;
    public int bombDamage = 10;
    public float explosionRadius = 5f;
    public float throwCooldown = 0.5f;
    float cooldownTimer = 0f;
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
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        Debug.Log("Damage = " + bombDamage);
    }
    void ThrowBomb()
    {
        if (cooldownTimer > 0)
        {
            return;
        }

        cooldownTimer = throwCooldown;

        GameObject bomb = Instantiate(bombPrefab, throwPoint.position, Quaternion.identity);

        BombController bombController = bomb.GetComponent<BombController>();

        bombController.damage = bombDamage;

        bombController.explodeRadius = explosionRadius;

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
