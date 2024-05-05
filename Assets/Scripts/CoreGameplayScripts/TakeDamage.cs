using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
   
    [SerializeField] WeaponsManagerSO weaponManagerSO;
    [SerializeField] HpManagerSO hpManagerSO;
    private int damageValue;
    private void Update()
    {
        GetWeaponDamageValue();
    }

    private void GetWeaponDamageValue()
    {
        damageValue = weaponManagerSO.DamageValue();
    }

    private void OnTriggerEnter(Collider other)
    {
        //This triggers the HpManagerSO.HPchangeEvent event
        if (other.gameObject.GetComponent<WeaponDamageIdentifier>())
        {
            if (this.gameObject.layer == 6)
            {
                hpManagerSO.DamageHP(damageValue);
                print(damageValue);
                //print(other.gameObject);
            }
        }
    }
}