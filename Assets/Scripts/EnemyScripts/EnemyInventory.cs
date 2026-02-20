using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInventory : CharacterInventoryManager
{
    [field: SerializeField] public WeaponItemSO rightHandWeapon { get; private set; }
    [field: SerializeField] public WeaponItemSO leftHandWeapon { get; private set; }

    [SerializeField] GameObject weaponSlot;
    [field:SerializeField] public WeaponDamageCollider weaponDamageCollider;

    // Start is called before the first frame update
    void Start()
    {
        //LoadWeaponDamageCOllider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadWeapon(GameObject weapon)
    {
        weapon.transform.parent = weaponSlot.transform;

        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
    }



    public void LoadWeaponDamageCollider()
    {
        weaponDamageCollider = weaponSlot.gameObject.GetComponentInChildren<WeaponDamageCollider>();
    }

    public void OpenWeaponDamageCollider()
    {
        LoadWeaponDamageCollider();
        weaponDamageCollider.EnableWeaponCollider();
    }

    public void CloseWeaponDamageCollider()
    {
        LoadWeaponDamageCollider();
        weaponDamageCollider.DisableWeaponCollider();
    }
}
