using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : StateMachineController
{
    PlayerInputManager playerInputManager;
    PlayerMovement playerMovement;
    PlayerAttacks playerAttacks;

    [Header("Character States")]
    public State idleState; //Try [SerializeField] after making sure this works
    public State runState;
    public State attackState;

    [SerializeField] float playerMovementSpeed = 7;
    [SerializeField] float stopMovement = 0;
    [SerializeField] Canvas pauseGame;

    private void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        playerInputManager.OnPause += PlayerInputManager_OnPause;

        playerMovement = GetComponent<PlayerMovement>();
        playerAttacks = GetComponent<PlayerAttacks>();

        SetUpStateInstances();
        stateMachine.Set(idleState);
    }

    private void Update()
    {
        SetCharacterState();
        stateMachine.state.StartState();
    }

    void FixedUpdate()
    {
        playerMovement.HandleMovement();
        playerAttacks.SwordSwing();
    }

    private void PlayerInputManager_OnPause(object sender, System.EventArgs e)
    {
        if (Time.timeScale != 0)
        {
            pauseGame.gameObject.SetActive(true);

            Time.timeScale = 0;
            Debug.Log("Game Paused");
        }
        else
        {
            pauseGame.gameObject.SetActive(false);

            Time.timeScale = 1;
            Debug.Log("Game Unpaused");

        }
    }
    public void EndGame()
    {
        Application.Quit();
    }


    private void SetCharacterState()
    {
        if (groundCheck.isGrounded)
        {
            if (playerInputManager.moveInput == Vector2.zero && playerInputManager.attackInput != true)
            {
                stateMachine.Set(idleState);
            }
            else if(playerInputManager.moveInput != Vector2.zero && playerInputManager.attackInput != true)
            {
                playerMovement.movementSpeed = playerMovementSpeed;
                stateMachine.Set(runState);
            }
            else if (playerInputManager.attackInput == true)
            {
                playerMovement.movementSpeed = stopMovement;   
                stateMachine.Set(attackState);
            }
        }
    }
}
