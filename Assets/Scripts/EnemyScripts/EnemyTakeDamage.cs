using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    [SerializeField] WeaponsManagerSO weaponManagerSO;
    [SerializeField] HpManagerSO hpManagerSO;
    [SerializeField] LayerMask layerMask;
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
            if(((1<< other.gameObject.layer) & layerMask) != 0)
            {
                hpManagerSO.DamageHP(damageValue);
                print(damageValue);
                //print(other.gameObject);
            }
        }
    }
}
