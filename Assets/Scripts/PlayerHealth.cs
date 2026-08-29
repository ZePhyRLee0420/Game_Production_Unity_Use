using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    private bool isInvincible = false;

    float pushPower = 2f;

    PlayerDashController playerDash;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;

        playerDash = GetComponent<PlayerDashController>();

        playerDash.OnDashStart += StartInvincible;
        playerDash.OnDashEnd += EndInvincible;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //死亡時の処理
    void Die()
    {
        Destroy(gameObject);
    }

    //ダメージ処理
    public void takeDamage(int value)
    {
        if (isInvincible)
        {
            return;
        }

        currentHP -= value;

        if (currentHP <= 0)
        {
            Die();
        }
    }
    void StartInvincible()
    {
        isInvincible = true;
    }

    void EndInvincible()
    {
        isInvincible = false;
    }
    void OnDestroy()
    {
        if (playerDash != null)
        {
            playerDash.OnDashStart -= StartInvincible;
            playerDash.OnDashEnd -= EndInvincible;
        }
    }
    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.collider.CompareTag("Bomb"))
    //    {
    //        return;
    //    }

    //    Rigidbody body = hit.collider.attachedRigidbody;

    //    // no rigidbody
    //    if (body == null || body.isKinematic)
    //    {
    //        return;
    //    }

    //    // We dont want to push objects below us
    //    if (hit.moveDirection.y < -0.3)
    //    {
    //        return;
    //    }

    //    // Calculate push direction from move direction,
    //    // we only push objects to the sides never up and down
    //    Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

    //    // If you know how fast your character is trying to move,
    //    // then you can also multiply the push velocity by that.

    //    // Apply the push
    //    body.linearVelocity = pushDir * pushPower;
    //}
}
