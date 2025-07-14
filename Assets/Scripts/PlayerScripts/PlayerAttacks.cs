using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    PlayerInputManager playerInputManager;

    public float attackReset;
    private bool canAttack;

    [SerializeField] GameObject weaponObject;
    [SerializeField] AnimationClip attackAnimaton;
    [SerializeField] WeaponItemSO playerWeapon;
    [SerializeField] AttackState playerAttackState;
    [SerializeField] WeaponDamageCollider weaponDamageCollider;
    PlayerEquipmentManager equipmentManager;
    // Start is called before the first frame update
    void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        equipmentManager = GetComponent<PlayerEquipmentManager>();
    }

    private void Update()
    {
        // weaponObject = equipmentManager.GetCurrentWeapon();
        PlayerAttack();
        
    }
    public void PlayerAttack()
    {
        playerWeapon = equipmentManager.GetCurrentWeapon();
        weaponObject = equipmentManager.GetCurrentEquippedWeapon();

        if(playerWeapon != null)
        {
            attackAnimaton = playerWeapon.weaponAnimationClip;
            playerAttackState.SetAttackAnimation(attackAnimaton);
        }
        else
        {
            return;
        }
        
        if (playerInputManager.attackInput == true && playerWeapon != null)
        {
            attackReset += Time.deltaTime;

            if (attackReset >= attackAnimaton.length * .55f)
            {
                playerInputManager.attackInput = false;
            }
        }
        else if (playerInputManager.attackInput == false || playerWeapon == null)
        {
            attackReset = 0;
            return;
        }
    }

    public void EnableDamageCollider()
    {
        weaponDamageCollider = weaponObject.GetComponentInChildren<WeaponDamageCollider>();
        weaponDamageCollider.gameObject.GetComponent<Collider>().enabled = true;
    }

    public void DisableDamageCollider()
    {
        weaponDamageCollider = weaponObject.GetComponentInChildren<WeaponDamageCollider>();
        weaponDamageCollider.gameObject.GetComponent<Collider>().enabled = false;
    }
}