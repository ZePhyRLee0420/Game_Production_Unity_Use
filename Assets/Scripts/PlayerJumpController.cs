using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    public float jumpHeight = 5f;
    public float gravity = -20f;
    float verticalVelocity;
    bool jumpRequested = false;
    CharacterController agent;
    PlayerInputHandler inputHandler;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<CharacterController>();
        inputHandler = GetComponent<PlayerInputHandler>();

        inputHandler.OnJump += RequestJump;
    }

    // Update is called once per frame
    void Update()
    {
        Gravity();

        if (jumpRequested)
        {
            Jump();
            jumpRequested = false;
        }
    }
    void RequestJump()
    {
        jumpRequested = true;
    }
    void Jump()
    {
        if (!agent.isGrounded)
            return;

        verticalVelocity = Mathf.Sqrt(
            jumpHeight * -2f * gravity
        );
    }
    void Gravity()
    {
        if (agent.isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 verticalMovement =
            Vector3.up * verticalVelocity * Time.deltaTime;

        agent.Move(verticalMovement);
    }
    void OnDestroy()
    {
        if (inputHandler != null)
        {
            inputHandler.OnJump -= RequestJump;
        }
    }
}
