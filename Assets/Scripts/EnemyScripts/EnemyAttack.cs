using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    EnemyInventory enemyInventory;

    [SerializeField] Transform target;
    [SerializeField] Transform weaponSlot;

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

        if(attackDistance < 5f)
        {
            canAttackPlayer = true;
            //animator.SetLayerWeight(layerIndex, layerWeight);
            //animator.SetTrigger("attack");
            //weaponSlot.GetChild(0).GetComponent<Collider>().enabled = true;
        }

        else
        {
            canAttackPlayer = false;
            //animator.SetLayerWeight(0, 0);
            //weaponSlot.GetChild(0).GetComponent<Collider>().enabled = false;
        }
    }

    //Shouldn't be using null progagation (?.), but they're working, so oh well
    public void EnableWeaponCollider()
    {
        enemyInventory?.OpenWeaponDamageCollider();
    }

    public void DisableWeaponCollider()
    {
        enemyInventory?.CloseWeaponDamageCollider();

    }
}
