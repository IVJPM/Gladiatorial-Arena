using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class EnemyManager : CharacterManager
{
    [Header("Character States")]
    public State idleState; //Try [SerializeField] after making sure this works
    public State runState;
    public State attackState;
    public State deathState;
    public State pursueState;
    public State engageTarget;

    [SerializeField] float chasePlayerSpeed;
    private float activeTimer;


    EnemyMovement enemyMovement;
    EnemyStats enemyStats;
    EnemyAttack enemyAttack;

    [SerializeField] HpManagerSO hpManagerSO;
    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyStats = GetComponent<EnemyStats>();
        enemyAttack = GetComponent<EnemyAttack>();

        SetUpStateInstances();
        stateMachine.Set(idleState);
        //stateMachine.state.PerformStateBranch();
    }

    // Update is called once per frame
    void Update()
    {
        SetCharacterState();
        stateMachine.state.PerformState();
    }


    void FixedUpdate()
    {
        enemyMovement.HandleEnemyMovement();
        enemyAttack.AttackTarget();
    }

    private void SetCharacterState()
    {
        if (groundCheck.isGrounded)
        {
            if (enemyMovement.chasingPlayer == false && enemyStats.currentHealth != 0 && !enemyAttack.canAttackPlayer)
            {
                stateMachine.Set(idleState);
            }
            else if (enemyMovement.chasingPlayer == true && enemyStats.currentHealth != 0 && !enemyAttack.canAttackPlayer)
            {
                enemyMovement.enemyRunSpeed = chasePlayerSpeed;
                stateMachine.Set(runState);
            }
            else if(enemyAttack.canAttackPlayer && enemyStats.currentHealth != 0)
            {
                stateMachine.Set(pursueState);
            }
            else if (enemyStats.currentHealth <= 0)
            {
                stateMachine.Set(deathState);
                enemyMovement.enemyRunSpeed = 0;
                StartCoroutine(DestroyEnemy());
            }
        }
        //stateMachine.state.PerformStateBranch();
    }

    private void GetAttackState()
    {
        stateMachine.Set(attackState);
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    IEnumerator EnemyAttackIntervals()
    {
        yield return new WaitForSeconds(3);
        pursueState.GetComponent<PursueState>().intervalTracker = 0;
    }
}
