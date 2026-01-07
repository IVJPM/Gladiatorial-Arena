using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    PlayerInputs playerInputs;

    public float horizontalInput;
    public float verticalInput;
    public Vector2 moveInput;

    public float moveAmount;
    public bool attackInput;
    public bool interact = false;
    public bool isDodging;

    [Header("Camera Movment Inputs")]
    public float cameraHorizontalInput;
    public float cameraVerticalInput;
    public Vector2 camRot;

    public event EventHandler OnInteract;
    public event EventHandler OnHeavyAttack;
    public event EventHandler OnPause;
    public event EventHandler OnDodge;

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
            playerInputs.PlayerMovement.PlayerDodge.performed += PlayerDodge_performed; ;

            playerInputs.CameraMovement.CameraMovement.performed += i => camRot = i.ReadValue<Vector2>();
            playerInputs.CameraMovement.CameraMovement.canceled += i => camRot = Vector2.zero;
            playerInputs.AttackInputs.AttackInputs.performed += i => attackInput = true;
            playerInputs.AttackInputs.HeavyAttack.performed += HeavyAttack_performed;
            playerInputs.InteractionInput.InteractionInput.performed += Interactable_performed;
            playerInputs.PauseMenu.Pause.performed += Pause_performed;
        }

        playerInputs.Enable();
    }

    private void HeavyAttack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnHeavyAttack?.Invoke(this, EventArgs.Empty);
    }

    private void PlayerDodge_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnDodge?.Invoke(this, EventArgs.Empty);
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPause?.Invoke(this, EventArgs.Empty);
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
}
