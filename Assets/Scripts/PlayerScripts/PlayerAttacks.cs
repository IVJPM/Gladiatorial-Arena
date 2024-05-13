using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : State
{
    PlayerInputManager playerInputManager;

    public float attackReset;
    private bool canAttack;
    [SerializeField] Transform weaponSlot;

    // Start is called before the first frame update
    void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwordSwing()
    {

        if (playerInputManager.attackInput == true)
        {
            //weaponSlot.GetChild(0).GetComponent<Collider>().enabled = true;
            attackReset += 15 * Time.deltaTime;
            //animator.SetLayerWeight(layerIndex, layerWeight);
            //animator.SetBool("oneHandedThrust", true);

            if (attackReset >= 11f)
            {
                playerInputManager.attackInput = false;
            }
        }
        else if (playerInputManager.attackInput == false)
        {
            //weaponSlot.GetChild(0).GetComponent<Collider>().enabled = false;
            //animator.SetLayerWeight(layerIndex, 0);
            //animator.SetBool("oneHandedThrust", false);
            attackReset = 0;
        }
    }

    public void EnableWeaponCollider()
    {
        weaponSlot.GetChild(0).GetComponent<Collider>().enabled = true;
    }

    public void DisableWeaponCollider()
    {
        weaponSlot.GetChild(0).GetComponent<Collider>().enabled = false;

    }
}
