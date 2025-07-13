using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputManager playerInputManager;

    Rigidbody playerRB;
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
    public bool isDodging;

    [SerializeField] Transform shin;
    [SerializeField] LayerMask groundedMask;
    [SerializeField] LayerMask slopeMask;

    [SerializeField] float dodgeTimer;

    RaycastHit groundedCastHit;

    Vector3 moveDirection;
    // Start is called before the first frame update
    void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        playerInputManager.OnDodge += PlayerInputManager_OnDodge;

        playerRB = GetComponent<Rigidbody>();
    }

    private void PlayerInputManager_OnDodge(object sender, System.EventArgs e)
    {
        if(!isDodging)
        {
            isDodging = true;
        }
    }

    private void Start()
    {
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        GetPlayerMovementInputs();
    }

    private void FixedUpdate()
    {
        if (!CheckIfGrounded() && !OnSlope())
        {
            playerRB.AddForce(Vector3.down * 20f, ForceMode.Impulse);
        }
        HandleMovement();
        //HandleDodge();
    }

    private void GetPlayerMovementInputs()
    {
        horizontalInput = playerInputManager.horizontalInput;
        verticalInput = playerInputManager.verticalInput;
        moveInput = playerInputManager.moveInput;
        moveAmount = playerInputManager.moveAmount;
    }

    public void HandleMovement()
    {
        move = new Vector3(moveInput.x, 0, moveInput.y);
        move.Normalize();

        float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + camTurn.transform.eulerAngles.y;
        if (move != Vector3.zero)
        {
            if (CheckIfGrounded() && !isDodging)
            {
                moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

                Quaternion rotate = Quaternion.Euler(0, targetAngle, 0);

                playerRB.linearVelocity = moveDirection * movementSpeed;

                playerRB.MoveRotation(Quaternion.Slerp(playerRB.rotation, rotate, 10f * Time.deltaTime));
            }

            if (OnSlope() && !isDodging)
            {
                playerRB.useGravity = false;
                moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

                Quaternion rotate = Quaternion.Euler(0, targetAngle, 0);

                playerRB.MoveRotation(Quaternion.Slerp(playerRB.rotation, rotate, 10f * Time.deltaTime));

                playerRB.linearVelocity = GetSlopeMovementDirection() * movementSpeed ;

                if (playerRB.linearVelocity.y > 0f)
                {
                    playerRB.AddForce(Vector3.down * 80f, ForceMode.Force);
                }
            }
        }
    }

    public void HandleDodge()
    {
        Vector3 dodgeDirection;
        dodgeDirection = playerRB.transform.forward;
        
        if(isDodging && dodgeTimer < .75f)
        {
            dodgeTimer += Time.deltaTime;
            if(dodgeTimer >= .15f)
            {
                playerRB.linearVelocity = dodgeDirection * 20f;
            }
        }
        else if(dodgeTimer >= .75f)
        {
            isDodging = false;
            dodgeTimer = 0;
        }
    }
    public bool CheckIfGrounded()
    {
        if (Physics.SphereCast(shin.position, .25f, transform.TransformDirection(Vector3.down), out groundedCastHit, .15f, groundedMask))
        {
            float slopeAngle = Vector3.Angle(Vector3.up, groundedCastHit.normal);
            return true;
        }
        return false;
    }

    public bool OnSlope()
    {
        if (Physics.SphereCast(shin.position, .25f, transform.TransformDirection(Vector3.down), out groundedCastHit, .15f, slopeMask))
        {
            float slopeAngle = Vector3.Angle(Vector3.up, groundedCastHit.normal);
            return slopeAngle < 55;
        }
        return false;
    }

    private Vector3 GetSlopeMovementDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, groundedCastHit.normal).normalized;
    }
}
