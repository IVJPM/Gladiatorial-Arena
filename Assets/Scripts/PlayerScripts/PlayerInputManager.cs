using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    PlayerInputs playerInputs;
    public float horizontalInput;
    public float verticalInput;
    public float moveAmount;
    public Vector2 moveInput;
    public bool attackInput = false;
    public bool interact = false;

    [Header("Camera Movment Inputs")]
    public float cameraHorizontalInput;
    public float cameraVerticalInput;
    Vector2 camRot;

    public event EventHandler OnInteract;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovementInputs();
        CameraInputs();
    }

    private void OnEnable()
    {
        if (playerInputs == null)
        {
            playerInputs = new PlayerInputs();
            playerInputs.PlayerMovement.PlayerMovement.performed += i => moveInput = i.ReadValue<Vector2>();
            playerInputs.CameraMovement.CameraMovement.performed += i => camRot = i.ReadValue<Vector2>();
            playerInputs.AttackInputs.AttackInputs.performed += i => attackInput = true;
            playerInputs.InteractionInput.InteractionInput.performed += Interactable_performed;
        }

        playerInputs.Enable();

    }

    private void Interactable_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteract?.Invoke(this, EventArgs.Empty);
    }

    private void CameraInputs()
    {
        cameraHorizontalInput = camRot.y;
        cameraVerticalInput = camRot.x;
    }

    private void MovementInputs()
    {
        verticalInput = moveInput.y;
        horizontalInput = moveInput.x;
        // moveInput = new Vector3(horizontalInput, 0, verticalInput);
        moveAmount = Mathf.Clamp01(Mathf.Abs(verticalInput) + Mathf.Abs(horizontalInput));
    }

    private void AttackInput()
    {

    }
}
