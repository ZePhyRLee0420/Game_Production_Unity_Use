using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputAction moveAction;
    //InputAction dashAction;
    public float moveSpeed = 2f;
    public float turnSpeed = 20f;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    //Animator m_Animator;


    //CharacterController character;
    NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        //m_Animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        m_Movement.Set(moveValue.x, 0f, moveValue.y);

        bool hasHorizontalInput = !Mathf.Approximately(moveValue.x, 0f);
        //Debug.Log("hasHorizontal" + hasHorizontalInput);
        bool hasVerticalInput = !Mathf.Approximately(moveValue.y, 0f);
        //Debug.Log("hasVertical" + hasVerticalInput);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
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
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);

        transform.rotation = m_Rotation;
        Vector3 forwardMovement = Vector3.forward * m_Movement.magnitude * moveSpeed * Time.deltaTime;
        //transform.Translate(forwardMovement);

        Vector3 motion = transform.TransformDirection(forwardMovement);
        //character.Move(motion);
        agent.Move(motion);
    }

}
