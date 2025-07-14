using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInventory : CharacterInventoryManager
{
    // public string itemName = "Items";
    public List<GameObject> ItemInventory = new List<GameObject>();
    private GameObject item;
    public float maxDistance;

    PlayerInputManager playerInputManager;
    PlayerManager playerManager;

    [SerializeField] float sphereRadius;
    [SerializeField] LayerMask itemLayerMask;
    [SerializeField] GameObject weaponSlot; // Refactor into 'rightHandWeaponSlot' and 'leftHandWeaponSlot'
    [SerializeField] PlayerInteractables playerInteractables;
    [field: SerializeField] public WeaponItemSO rightHandWeapon {  get; private set; }
    [field: SerializeField] public WeaponItemSO leftHandWeapon { get; private set; }

    [SerializeField] WeaponDamageCollider weaponDamageCollider;


    private void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        playerManager = GetComponent<PlayerManager>();
        //playerInteractables = GetComponent<PlayerInteractables>();
        playerInputManager.OnInteract += PlayerInputManager_OnInteract;

        //EquipWeapon(currentEquippedWeapon);
    }

    private void Update()
    {
        
    }

    private void PlayerInputManager_OnInteract(object sender, System.EventArgs e)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, sphereRadius, itemLayerMask);
        foreach (Collider hit in hitColliders)
        { 
            if(hitColliders != null)
            {
                Debug.Log(hit.transform.gameObject);
                //AddItemToInventory(hit.gameObject);
            }
        }
    }

    private void AddItemToInventory(GameObject item)
    {
        Vector3 itemTransform = item.transform.position;
        itemTransform.y = transform.position.y;
        Quaternion pickUpItem = Quaternion.LookRotation(itemTransform - transform.position, Vector3.up);
        Quaternion.RotateTowards(transform.rotation, pickUpItem, 360f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, pickUpItem, 360f);

        ItemInventory.Add(item);
        item.SetActive(false);
    }

    public void LoadWeapon(GameObject weapon)
    {
        weapon.transform.parent = weaponSlot.transform;

        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
    }

    public void WeaponChange(WeaponItemSO changeWeapon)
    {
        rightHandWeapon = changeWeapon;
    }
    public void CharacterEquippedItem(CharacterManager character)
    {
        character = playerManager;
    }

    public void LoadWeaponDamageCOllider()
    {
        weaponDamageCollider = rightHandWeapon.weaponModel.GetComponentInChildren<WeaponDamageCollider>();
    }

    public void OpenWeaponDamageCollider()
    {
        weaponDamageCollider.EnableWeaponCollider();
    }

    public void CloseWeaponDamageCollider()
    {
        weaponDamageCollider.DisableWeaponCollider();
    }
}
