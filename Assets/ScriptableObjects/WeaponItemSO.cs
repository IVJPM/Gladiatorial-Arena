using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponItemSO : Item
{
    [Header("Weapon Model")]
    public GameObject weaponModel;
    public bool isRightHandWeapon;
    public bool isLeftHandWeapon;
    public bool isEquipped = false;
    public AnimationClip weaponAnimationClip;
    public AnimationClip weaponComboClip;


    [Header("Weapon Base Damage")]
    public int weaponDamage;

    [Range(0f, 1f)]
    public float weaponResetSpeed;
}
