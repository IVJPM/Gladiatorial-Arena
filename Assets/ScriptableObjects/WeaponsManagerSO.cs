using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponsManagerSO", menuName = "WeaponsManagerSO/Weapons")]

public class WeaponsManagerSO : ScriptableObject
{
    //Figure out a way to reference this Scriptable Object rather than the WeaponDamage script to take damage on only the player TakeDamage script

    [SerializeField] List<GameObject> weapons = new List<GameObject>();
    public IReadOnlyList<GameObject> Weapon => weapons;
   // public string weaponName = "";
    private int damage;

    public int DamageValue()
    {
        foreach (GameObject weapon in weapons)
        {
            if (weapon.CompareTag ("UnarmedWeapon"))
            {
                UnarmedWeaponDamage(damage);
                break;
            }

            if (weapon.CompareTag ("Sword"))
            {
                SwordDamage(damage);
                break;
            }

            if (weapon.CompareTag  ("Axe"))
            {
                AxeDamage(damage);
                break;
            }

            if (weapon.CompareTag ("Dagger"))
            {
                DaggerDamage(damage);
                break;
            }
        }
        return damage;
    }

    public int UnarmedWeaponDamage(int unarmedDamage)
    {
        unarmedDamage = 5;
        damage = unarmedDamage;
        return damage;
    }

    public int SwordDamage(int swordDamage)
    {
        swordDamage = 15;
        damage = swordDamage;
        return swordDamage;
    }

    public int AxeDamage(int axeDamage)
    {
        axeDamage = 21;
        damage = axeDamage;
        return axeDamage;
    }

    public int DaggerDamage(int daggerDamage)
    {
        daggerDamage = 11;
        damage = daggerDamage;
        return daggerDamage;
    }
}
