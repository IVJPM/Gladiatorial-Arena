using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputManager playerInputManager;

    Rigidbody rigidbody;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    [SerializeField] GameObject camTurn;

    [Header("Player inputs")]
    public float moveAmount;
    public Vector2 moveInput; 
    public Vector3 move;
    public float gravityModifier;
    public float movementSpeed;
    public float resetMovementSpeed;


    // Start is called before the first frame update
    void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {

    }

    public void HandleMovement()
    {
        horizontalInput = playerInputManager.horizontalInput;
        verticalInput = playerInputManager.verticalInput;
        moveInput = playerInputManager.moveInput;
        moveAmount = playerInputManager.moveAmount;

        move = new Vector3(moveInput.x, 0, moveInput.y);
        move.Normalize();

        if (move != Vector3.zero)
        {
            Vector3 camForward = camTurn.transform.forward;
            camForward.y = 0;
            Quaternion camRelativeRotation = Quaternion.FromToRotation(Vector3.forward, camForward * Time.deltaTime);
            Vector3 lookToward = camRelativeRotation * move;
            Quaternion camPlayerRotation = Quaternion.LookRotation(lookToward, Vector3.up);
            rigidbody.velocity = lookToward * movementSpeed;

            Quaternion finalRotation = Quaternion.RotateTowards(rigidbody.rotation, camPlayerRotation, 750 * Time.fixedDeltaTime);
            Quaternion smoothRotation = Quaternion.Slerp(camPlayerRotation, finalRotation, 100);
            rigidbody.MoveRotation(smoothRotation);
        }
    }
}
