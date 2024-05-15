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
    private int healValue;

    private void OnTriggerEnter(Collider other)
    {
        //This triggers the HpManagerSO.HPchangeEvent event
        if (other.gameObject.TryGetComponent(out IWeapons weapons))
        {
            damageValue = weapons.WeaponBaseDamage();
            if (this.gameObject.layer == 3)
            {
                hpManagerSO.DamageHP(damageValue);
                print(damageValue);
            }
        }
        else if (other.gameObject.TryGetComponent(out HealingItem item))
        {
            healValue = item.ItemHealAmount();
            hpManagerSO.HealHP(healValue);
            Destroy(other.gameObject);
        }
    }
}