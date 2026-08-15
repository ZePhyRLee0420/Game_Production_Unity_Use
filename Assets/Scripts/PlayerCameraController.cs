using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraController : MonoBehaviour
{
    public Transform cameraPoint;

    public float sensitivity = 0.15f;

    InputAction lookAction;

    float yaw;
    float pitch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lookAction = InputSystem.actions.FindAction("Look");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookValue = lookAction.ReadValue<Vector2>();

        yaw += lookValue.x * sensitivity;
        pitch -= lookValue.y * sensitivity;

        pitch = Mathf.Clamp(pitch, -30f, 60f);

        cameraPoint.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}
