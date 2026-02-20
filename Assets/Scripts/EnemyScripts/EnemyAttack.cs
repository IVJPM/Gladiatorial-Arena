using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    EnemyInventory enemyInventory;

    [SerializeField] Transform target;
    [SerializeField] Transform weaponSlot;
    [SerializeField] bool transitionAttack;

    private float attackDistance;

    public bool canAttackPlayer {  get; private set; }


    private void Awake()
    {
        enemyInventory = GetComponent<EnemyInventory>();
    }
    // Update is called once per frame
    void Update()
    {
        //AttackTarget();
        //enemyInventory.LoadWeaponDamageCOllider();
    }

    public void AttackTarget()
    {
        attackDistance = Vector3.Distance(transform.position, target.position);

        if(attackDistance < 1.15f)
        {
            canAttackPlayer = true;
            //StartCoroutine(EnemyAttackIntervals());
        }

        else
        {
            canAttackPlayer = false;
        }
    }

    //Shouldn't be using null progagation (?.), but they're working, so oh well
    public void EnableWeaponCollider()
    {
        enemyInventory.OpenWeaponDamageCollider();
    }

    public void DisableWeaponCollider()
    {
        enemyInventory.CloseWeaponDamageCollider();

    }

    public void ResetChainAttack()
    {
        transitionAttack = false;
    }

    IEnumerator EnemyAttackIntervals()
    {
        canAttackPlayer = false;
        yield return new WaitForSeconds(Random.Range(0, 2));
        canAttackPlayer = true;
        
    }
}
