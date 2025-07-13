using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEquipmentManager : MonoBehaviour
{
    [SerializeField] GameObject currentEquippedWeapon;
    [SerializeField] WeaponItemSO currentWeapon;
    [SerializeField] WeaponsManager weaponsManager;

    [SerializeField] float sphereRadius;
    [SerializeField] LayerMask itemLayerMask;

    PlayerInventory playerInventory;
    PlayerManager playerManager;
    PlayerInputManager playerInputManager;
    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
        playerManager = GetComponent<PlayerManager>();

        EquipWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EquipWeapon()
    {
        if(playerInventory.rightHandWeapon != null)
        {
            playerInventory.CharacterEquippedItem(playerManager);

            currentWeapon = playerInventory.rightHandWeapon;
            playerInventory.rightHandWeapon.isEquipped = true;

            currentEquippedWeapon = Instantiate(currentWeapon.weaponModel);
            playerInventory.LoadWeapon(currentEquippedWeapon);

            weaponsManager = currentEquippedWeapon.GetComponent<WeaponsManager>();
            weaponsManager.GetComponent<Collider>().enabled = false;

            weaponsManager.SetWeaponDamage(currentWeapon);
            playerInventory.LoadWeaponDamageCOllider();
        }
        else
        {
            Debug.Log("no weapon");
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out WeaponsManager weapon))
        {
            if(weapon != currentWeapon && !weapon.weaponItem.isEquipped)
            {
                Destroy(currentEquippedWeapon);
                currentWeapon = weapon.weaponItem;
                playerInventory.WeaponChange(currentWeapon);
                EquipWeapon();
            }
        }
        else
        {
            return;
        }
    }

    public WeaponItemSO GetCurrentWeapon()
    {
        return currentWeapon;
    }

    public GameObject GetCurrentEquippedWeapon()
    {
        return currentEquippedWeapon;
    }
}
