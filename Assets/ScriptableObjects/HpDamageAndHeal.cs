using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpDamageAndHeal : MonoBehaviour
{//Been replaced with the WeaponDamage script to apply to different weapons
    private int damageHealth;
    [SerializeField] HpManagerSO hpManagerSO;

    //This triggers the HpManagerSO.HPchangeEvent event
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            hpManagerSO.DamageHP(damageHealth);
    }
}
