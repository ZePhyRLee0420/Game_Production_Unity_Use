using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    Animator m_Animator;
    PlayerInputHandler playerInputHandler;
    PlayerDashController dashController;

    float time = 0.0f;
    bool isWalking = false;
    bool isDashing = false;
    Vector2 moveValue = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        playerInputHandler = GetComponent<PlayerInputHandler>();
        dashController = GetComponent<PlayerDashController>();

        playerInputHandler.OnMove += HandleMove;
        playerInputHandler.OnThrow += HandleThrow;
        playerInputHandler.OnJump += HandleJump;

        dashController.OnDashStart += HandleDashStart;
        dashController.OnDashEnd += HandleDashEnd;
    }

    // Update is called once per frame
    void Update()
    {
        isWalking = moveValue.sqrMagnitude > 0.01f;

        m_Animator.SetBool("isWalking", isWalking);

        if (isWalking)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0f;
        }

        float blendTime = Mathf.Clamp01((time - 0.5f) / 0.1f);

        if (isDashing && isWalking)
        {
            blendTime = 1f;
        }

        m_Animator.SetFloat("moveTime", blendTime);
    }
    void HandleMove(Vector2 value)
    {
        moveValue = value;
    }
    void HandleThrow()
    {
        m_Animator.SetTrigger("Throw");
    }

    void HandleJump()
    {
        m_Animator.SetTrigger("Jump");
    }
    void HandleDashStart()
    {
        isDashing = true;
        m_Animator.SetBool("isDashing", true);
    }

    void HandleDashEnd()
    {
        isDashing = false;
        m_Animator.SetBool("isDashing", false);
    }
    void OnDestroy()
    {
        if (playerInputHandler != null)
        {
            playerInputHandler.OnMove -= HandleMove;
            playerInputHandler.OnThrow -= HandleThrow;
            playerInputHandler.OnJump -= HandleJump;
        }

        if (dashController != null)
        {
            dashController.OnDashStart -= HandleDashStart;
            dashController.OnDashEnd -= HandleDashEnd;
        }
    }
}
