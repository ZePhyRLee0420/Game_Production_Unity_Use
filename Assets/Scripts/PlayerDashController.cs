using UnityEngine;
using System.Collections;

public class PlayerDashController : MonoBehaviour
{
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    private bool canDash = true;

    PlayerInputHandler inputHandler;

    public delegate void DashHandler();
    public event DashHandler OnDashStart;
    public event DashHandler OnDashEnd;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputHandler = GetComponent<PlayerInputHandler>();

        inputHandler.OnDash += StartDash;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void StartDash()
    {
        if (!canDash)
            return;

        StartCoroutine(Dash());
    }
    IEnumerator Dash()
    {
        canDash = false;

        OnDashStart?.Invoke();

        yield return new WaitForSeconds(dashDuration);

        OnDashEnd?.Invoke();

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }
    void OnDestroy()
    {
        if (inputHandler != null)
        {
            inputHandler.OnDash -= StartDash;
        }
    }
}
