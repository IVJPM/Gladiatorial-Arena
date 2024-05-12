using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class EnemyManager : StateMachineController
{
    [Header("Character States")]
    public State idleState; //Try [SerializeField] after making sure this works
    public State runState;
    public State attackState;

    [SerializeField] float chasePlayerSpeed;

    EnemyMovement enemyMovement;
    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();

        SetUpStateInstances();
        stateMachine.Set(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        SetCharacterState();
        stateMachine.state.StartState();
    }


    void FixedUpdate()
    {
        enemyMovement.HandleEnemyMovement();
    }

    private void SetCharacterState()
    {
        if (groundCheck.isGrounded)
        {
            if (enemyMovement.enemyRB.velocity == Vector3.zero)
            {
                stateMachine.Set(idleState);
            }
            else if (enemyMovement.enemyRB.velocity != Vector3.zero)
            {
                //enemyMovement.enemyRunSpeed = chasePlayerSpeed;
                stateMachine.Set(runState);
            }
            else if (enemyMovement.canAttack == true)
            {
                stateMachine.Set(attackState);
            }
        }
    }
}
