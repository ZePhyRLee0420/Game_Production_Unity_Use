using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    InputAction moveAction;
    InputAction throwAction;

    public delegate void MoveInputHandler(Vector2 moveValue);
    public event MoveInputHandler OnMove;

    public delegate void ButtonInputHandler();
    public event ButtonInputHandler OnThrow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        throwAction = InputSystem.actions.FindAction("Throw");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        OnMove?.Invoke(moveValue);

        if (throwAction.WasPressedThisFrame())
        {
            OnThrow?.Invoke();
        }
    }
}
