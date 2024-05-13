using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : StateMachineController
{
    [Header("Character States")]
    public State idleState; //Try [SerializeField] after making sure this works
    public State runState;
    public State attackState;
    public State deathState;

    [SerializeField] float chasePlayerSpeed;
    private float activeTimer;


    EnemyMovement enemyMovement;
    EnemyAttack enemyAttack;

    [SerializeField] HpManagerSO hpManagerSO;
    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAttack = GetComponent<EnemyAttack>();

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
        enemyAttack.AttackTarget();
    }

    private void SetCharacterState()
    {
        if (groundCheck.isGrounded)
        {
            if (enemyMovement.chasingPlayer == false && hpManagerSO.HP != 0)
            {
                if (enemyAttack.canAttackPlayer == true)
                {
                    stateMachine.Set(attackState);
                }
                else
                {
                    stateMachine.Set(idleState);
                }
            }
            else if (enemyMovement.chasingPlayer == true && hpManagerSO.HP != 0)
            {
                enemyMovement.enemyRunSpeed = chasePlayerSpeed;
                stateMachine.Set(runState);
            }
            else if(hpManagerSO.HP <= 0)
            {
                stateMachine.Set(deathState);
                StartCoroutine(DestroyEnemy());
            }
        }
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

}
