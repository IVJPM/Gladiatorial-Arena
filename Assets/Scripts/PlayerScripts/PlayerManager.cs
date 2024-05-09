using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{


    PlayerInputManager playerInputManager;
    private enum PlayerActionState
    {
        Idle,
        Moving,
        Attacking,
        Interacting
    }

    private enum PlayerSubState
    {
        Unarmed,
        Armed
    }
    private PlayerSubState currentSubState;

    private PlayerActionState currentPlayerState;


    private void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
    }
    private void Update()
    {
        if(playerInputManager.moveInput != Vector2.zero)
        {
            currentPlayerState = PlayerActionState.Moving;
        }
        else
        {
            currentPlayerState = PlayerActionState.Idle;
        }
        //Debug.Log(currentPlayerState.ToString());
    }

    private void GetPlayerMovement()
    {

    }
}
