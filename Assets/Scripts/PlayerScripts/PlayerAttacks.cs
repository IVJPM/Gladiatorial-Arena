using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    PlayerInputManager playerInputManager;

    public float attackReset;
    public int weaponDamage;

    [SerializeField] GameObject weaponObject;
    [SerializeField] AnimationClip attackAnimation;
    [SerializeField] AnimationClip comboAnimation;
    [SerializeField] WeaponItemSO playerWeapon;
    [SerializeField] AttackState playerAttackState;
    [SerializeField] WeaponDamageCollider weaponDamageCollider;
    [SerializeField] float testAttackTime;
    
    Animator animator;
    bool attacking;
    public bool transitionAttack;
    public bool comboAttack;
    PlayerEquipmentManager equipmentManager;
    // Start is called before the first frame update
    void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        equipmentManager = GetComponent<PlayerEquipmentManager>();
        animator = GetComponent<Animator>();

        playerInputManager.OnHeavyAttack += PlayerInputManager_OnHeavyAttack;
    }

    private void PlayerInputManager_OnHeavyAttack(object sender, EventArgs e)
    {
        if(transitionAttack && !comboAttack)
        {
            comboAttack = true;
            animator.CrossFade(playerWeapon.weaponComboClip.name, .1f);
            animator.SetFloat("animationSpeed", 1f);
            attackReset = 0f;
        }
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
            if(playerInputManager.attackInput && !comboAttack)
            {
                attackAnimation = playerWeapon.weaponAnimationClip;
                playerWeapon.RegularWeaponDamage();
            }
            else if(comboAttack)
            {
                attackAnimation = playerWeapon.weaponComboClip;
                playerWeapon.WeaponComboDamage();
            }

            playerAttackState.SetAttackAnimation(attackAnimation);
        }
        else
        {
            return;
        }
        
        if (playerInputManager.attackInput == true && playerWeapon != null || comboAttack && playerWeapon != null)
        {
            animator.SetFloat("animationSpeed", attackAnimation.apparentSpeed);

            attackReset += Time.deltaTime;


            if (attackReset >= attackAnimation.length)
            {
                animator.SetFloat("animationSpeed", playerWeapon.weaponResetSpeed); //Some animations reset too quickly, used to slow them down when needed
                if(attackAnimation == playerWeapon.weaponAnimationClip)
                {
                    playerInputManager.attackInput = false;
                }
                else
                {
                    comboAttack = false;
                }
                attackAnimation = playerWeapon.weaponAnimationClip;
                transitionAttack = false;
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

    public void ChainAttack()
    {
        transitionAttack = true;
        //print("combo");
    }

    public void ResetChainAttack()
    {
        transitionAttack = false;
    }

    public void TestComboEvent()
    {
        //print("success");
    }

    IEnumerator AttackResetTime()
    {
        testAttackTime += Time.deltaTime;
        yield return new WaitForSeconds(attackAnimation.length);
    }
}