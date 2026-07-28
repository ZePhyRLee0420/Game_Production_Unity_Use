using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputAction moveAction;
    InputAction attackAction;
    InputAction dashAction;
    public float moveSpeed = 2f;
    public float turnSpeed = 20f;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    //Animator m_Animator;

    float time = 0f;

    //CharacterController character;
    float pushPower = 2f;
    NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        //m_Animator = GetComponent<Animator>();
        //character = GetComponent<CharacterController>();
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
        //}
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
