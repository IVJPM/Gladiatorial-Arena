using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager
{
    PlayerInputManager playerInputManager;
    PlayerMovement playerMovement;
    PlayerAttacks playerAttacks;

    [Header("Character States")]
    public State idleState; //Try [SerializeField] after making sure this works
    public State runState;
    public State attackState;
    public State dodgeState;

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
        stateMachine.state.PerformState();
    }

    void FixedUpdate()
    {
        
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
        if (playerMovement.CheckIfGrounded() || playerMovement.OnSlope())
        {
            if (playerInputManager.moveInput == Vector2.zero && playerInputManager.attackInput != true && !playerAttacks.comboAttack && !playerMovement.isDodging)
            {
                stateMachine.Set(idleState);
            }
            else if(playerInputManager.moveInput != Vector2.zero && playerInputManager.attackInput != true && !playerAttacks.comboAttack && !playerMovement.isDodging)
            {
                playerMovement.movementSpeed = playerMovementSpeed;
                stateMachine.Set(runState);
            }
            else if (playerInputManager.attackInput == true && !playerMovement.isDodging || playerAttacks.comboAttack && !playerMovement.isDodging)
            {
                playerMovement.movementSpeed = stopMovement;   
                stateMachine.Set(attackState);
            }
            else if(playerMovement.isDodging && !playerInputManager.attackInput || playerMovement.isDodging && !playerAttacks.comboAttack)
            {
                stateMachine.Set(dodgeState);
            }
        }
    }
}
