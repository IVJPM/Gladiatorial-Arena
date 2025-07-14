using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    [SerializeField] WeaponDamageCollider damageCollider;
    public WeaponItemSO weaponItem;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWeaponDamage(WeaponItemSO weaponItem)
    {
        damageCollider.weaponDamage = weaponItem.weaponDamage;
    }

    public void GetWeaponItem(WeaponItemSO weapon)
    {
        weaponItem = weapon;
    }
}
