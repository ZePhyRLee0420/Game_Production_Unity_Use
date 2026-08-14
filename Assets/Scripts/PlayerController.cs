using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Transform cameraTransform;

    //InputAction dashAction;
    public float moveSpeed = 2f;
    public float turnSpeed = 20f;

    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    //Animator m_Animator;
    NavMeshAgent agent;

    PlayerInputHandler inputHandler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //m_Animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        inputHandler = GetComponent<PlayerInputHandler>();

        inputHandler.OnMove += SetMovement;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        //Debug.Log("isWalking" + isWalking);
        //m_Animator.SetBool("isWalking", isWalking);

        //if (isWalking)
        //{
        //    time += Time.deltaTime;
        //}
        //else
        //{
        //    time = 0f;
        //}
        //m_Animator.SetFloat("time", time);

        //AnimatorStateInfo baseState = m_Animator.GetCurrentAnimatorStateInfo(0);

        //bool isAttacking = baseState.IsTag("Attack");

        //if (!isAttacking)
        //{
    }
    void SetMovement(Vector2 moveValue)
    {
        m_Movement.Set(moveValue.x, 0f, moveValue.y);

        //bool isWalking = m_Movement != Vector3.zero;
    }
    void Movement()
    {
        if (m_Movement == Vector3.zero)
            return;

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * m_Movement.z + right * m_Movement.x;

        if (moveDirection != Vector3.zero)
        {
            Vector3 desiredForward =
                Vector3.RotateTowards(transform.forward, moveDirection, turnSpeed * Time.deltaTime, 0f);

            m_Rotation = Quaternion.LookRotation(desiredForward);
            transform.rotation = m_Rotation;
        }

        agent.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
    }
    void OnDestroy()
    {
        if (inputHandler != null)
        {
            inputHandler.OnMove -= SetMovement;
        }
    }
}
