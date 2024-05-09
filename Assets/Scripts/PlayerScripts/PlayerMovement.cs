using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : StateMachineController
{
    PlayerInputManager playerInputManager;

    [SerializeField] private float forwardSpeed;
    [SerializeField] private float sideSpeed;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    [SerializeField] GameObject camTurn;


    public float walkSpeed;
    public float runSpeed;
    public float moveAmount { get; private set; }  
    public Vector2 moveInput; 
    private Vector3 smoothVelocity;

    public Vector3 move;
    public bool isMoving;
    public float gravityModifier;

    public State idleState; //Try [SerializeField] after making sure this works
    public State runState;

    // Start is called before the first frame update
    void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
    }

    private void Start()
    {
        SetUpStateInstances();
        stateMachine.Set(idleState);
        isMoving = false;
    }

    private void Update()
    {
        SetCharacterState();

        stateMachine.state.StartState();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovement();
    }

    private void SetCharacterState()
    {
        if(groundCheck.isGrounded)
        {
            if (moveAmount == 0)
            {
                stateMachine.Set(idleState);
            }
            else
            {
                stateMachine.Set(runState);
            }
        }
    }

    private void HandleMovement()
    {
        horizontalInput = playerInputManager.horizontalInput;
        verticalInput = playerInputManager.verticalInput;
        moveInput = playerInputManager.moveInput;

        move = new Vector3(moveInput.x, 0, moveInput.y);
        move.Normalize();
        moveAmount = Mathf.Clamp01(Mathf.Abs(verticalInput) + Mathf.Abs(horizontalInput));

        //forwardSpeed = rigidbody.velocity.z;
        //sideSpeed = rigidbody.velocity.x;

        
        if (move != Vector3.zero)
        {
            isMoving = true;

            forwardSpeed = moveAmount;
            sideSpeed = moveAmount;

            Vector3 camForward = camTurn.transform.forward;
            camForward.y = 0;
            Quaternion camRelativeRotation = Quaternion.FromToRotation(Vector3.forward, camForward * Time.deltaTime);
            Vector3 lookToward = camRelativeRotation * move;
            Quaternion camPlayerRotation = Quaternion.LookRotation(lookToward, Vector3.up);
            //playerRb.AddForce(playerRb.position + moveInput + lookToward * .08f, ForceMode.Impulse);
            rigidbody.velocity = lookToward * 5.5f;

            Quaternion finalRotation = Quaternion.RotateTowards(rigidbody.rotation, camPlayerRotation, 900 * Time.fixedDeltaTime);
            //Quaternion smoothRotation = Quaternion.Slerp(camPlayerRotation, finalRotation, 10);
            //transform.rotation = smoothRotation;
            rigidbody.MoveRotation(finalRotation);

            //animator.SetFloat("forwardMove", forwardSpeed, .1f, Time.deltaTime); // Use for Idle as well
            //animator.SetFloat("sideMove", sideSpeed, .1f, Time.deltaTime);
        }
        else
        {
            isMoving = false;
        }
    }
}
