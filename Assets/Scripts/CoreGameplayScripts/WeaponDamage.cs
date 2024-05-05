using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int damage;
    int unarmedDamage;
    int swordDamage;
    int axeDamage;
    int daggerDamage;
    [SerializeField] WeaponsManagerSO weaponManagerSO;
    [SerializeField] HpManagerSO hpManagerSO;
    //public Testing player;

    // Make Inventory Manager (either SO or Singleton) to further reduce dependancies & allow cleaner communication between weapon scripts

    public int DamageValue()
    {
        foreach (GameObject weapon in weaponManagerSO.Weapon)
        {
            if (weapon.name == "UnarmedWeapon")
            {
                UnarmedWeaponDamage();
                damage = unarmedDamage;
                break;
            }

            if (weapon.name == "EnemySword")
            {
                SwordDamage();
                break;
            }

            if (weapon.name == "EnemyAxe")
            {
                AxeDamage();
                break;
            }

            if (weapon.name == "EnemyDagger")
            {
                DaggerDamage();
                break;
            }
        }return damage;
    }
    
    public void UnarmedWeaponDamage()
    {
        unarmedDamage = 5;
        damage = unarmedDamage;
    }

    public void SwordDamage()
    {
        swordDamage = 15;
        damage = swordDamage;
    }

    public void AxeDamage()
    {
        axeDamage = 21;
        damage = axeDamage;
    }

    public void DaggerDamage()
    {
        daggerDamage = 11;
        damage = daggerDamage;
    }

    
}
