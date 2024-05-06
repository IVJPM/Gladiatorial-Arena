using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputManager playerInputManager;

    [SerializeField] private float forwardSpeed;
    [SerializeField] private float sideSpeed;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    [SerializeField] GameObject camTurn;


    public float walkSpeed;
    public float runSpeed;
    public float moveAmount;
    public Vector2 moveInput;
    private Vector3 smoothVelocity;
    public Vector3 move;

    Rigidbody playerRb;
    Animator animator;
    public float gravityModifier;


    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        playerInputManager = GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        horizontalInput = playerInputManager.horizontalInput;
        verticalInput = playerInputManager.verticalInput;
        moveInput = playerInputManager.moveInput;

        move = new Vector3(moveInput.x, 0, moveInput.y);
        move.Normalize();

        forwardSpeed = move.z;
        sideSpeed = move.x;

        if (move == Vector3.zero)
        {
            animator.SetFloat("forwardMove", forwardSpeed, .1f, Time.deltaTime);
            animator.SetFloat("sideMove", sideSpeed, .1f, Time.deltaTime);
        }

        if (move != Vector3.zero)
        {
            forwardSpeed = move.z;
            sideSpeed = move.x;

            Vector3 camForward = camTurn.transform.forward;
            camForward.y = 0;
            Quaternion camRelativeRotation = Quaternion.FromToRotation(Vector3.forward, camForward * Time.deltaTime);
            Vector3 lookToward = camRelativeRotation * move;
            Quaternion camPlayerRotation = Quaternion.LookRotation(lookToward, Vector3.up);
            //playerRb.AddForce(playerRb.position + moveInput + lookToward * .08f, ForceMode.Impulse);
            playerRb.velocity = lookToward * 5.5f;

            Quaternion finalRotation = Quaternion.RotateTowards(playerRb.rotation, camPlayerRotation, 200 * Time.fixedDeltaTime);
            //Quaternion smoothRotation = Quaternion.Slerp(camPlayerRotation, finalRotation, 10);
            //transform.rotation = smoothRotation;
            playerRb.MoveRotation(finalRotation);

            animator.SetFloat("forwardMove", forwardSpeed, .1f, Time.deltaTime);
            animator.SetFloat("sideMove", sideSpeed, .1f, Time.deltaTime);
        }
    }
}
