using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
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

        bool isWalking = m_Movement != Vector3.zero;
    }
    void Movement()
    {
        if (m_Movement == Vector3.zero)
            return;

        Vector3 desiredForward =　Vector3.RotateTowards(transform.forward,　m_Movement,　turnSpeed * Time.deltaTime,　0f);

        m_Rotation = Quaternion.LookRotation(desiredForward);
        transform.rotation = m_Rotation;

        Vector3 forwardMovement =　Vector3.forward *　m_Movement.magnitude *　moveSpeed *　Time.deltaTime;

        Vector3 motion =　transform.TransformDirection(forwardMovement);

        agent.Move(motion);
    }
    void OnDestroy()
    {
        if (inputHandler != null)
        {
            inputHandler.OnMove -= SetMovement;
        }
    }
}
