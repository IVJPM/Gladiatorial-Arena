using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapons
{
    int WeaponBaseDamage();

    void EnableWeaponCollider();

    void DisableWeaponCollider();
}
