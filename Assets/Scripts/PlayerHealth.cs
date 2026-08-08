using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    //dash
    //public float dashSpeed = 15f;
    //public float dashDuration = 0.2f;
    //public float dashCooldown = 1f;
    //private bool isDashing = false;
    //private bool canDash = true;
    //InputAction dashAction;

    float time = 0f;
    float pushPower = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP < 0)
        {
            Die();
        }
    }

    //死亡時の処理
    void Die()
    {
        Destroy(gameObject);
    }

    //ダメージ処理
    public void takeDamage(int value)
    {
        currentHP -= value;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
        {
            return;
        }

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.linearVelocity = pushDir * pushPower;
    }
}
