using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    InputActionMap playerActionMap;
    //public bool inputEnabled = true;
    InputAction moveAction;
    InputAction throwAction;
    InputAction dashAction;
    InputAction jumpAction;

    public delegate void MoveInputHandler(Vector2 moveValue);
    public event MoveInputHandler OnMove;

    public delegate void ButtonInputHandler();
    public event ButtonInputHandler OnThrow;
    public event ButtonInputHandler OnDash;
    public event ButtonInputHandler OnJump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerActionMap = InputSystem.actions.FindActionMap("Player");

        moveAction = playerActionMap.FindAction("Move");
        throwAction = playerActionMap.FindAction("Throw");
        dashAction = playerActionMap.FindAction("Dash");
        jumpAction = playerActionMap.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        //if (!inputEnabled)
        //    return;

        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        OnMove?.Invoke(moveValue);

        if (throwAction.WasPressedThisFrame())
        {
            OnThrow?.Invoke();
        }

        if (dashAction.WasPressedThisFrame())
        {
            OnDash?.Invoke();
        }
        if (jumpAction.WasPressedThisFrame())
        {
            OnJump?.Invoke();
        }
    }
    public void EnablePlayerInput()
    {
        playerActionMap.Enable();
    }
    public void DisablePlayerInput()
    {
        playerActionMap.Disable();

        OnMove?.Invoke(Vector2.zero);
    }
}
