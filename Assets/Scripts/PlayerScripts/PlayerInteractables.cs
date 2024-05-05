using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractables : MonoBehaviour
{
    //public ScriptableObjectInventoryTest SOinventoryTest;
    PlayerInventory playerInventory;
    //[SerializeField] Transform weaponSlot;
    [SerializeField] float sphereRadius;
    private GameObject weaponItem;
    PlayerInputManager playerInputManager;
    public bool canInteract;
    


    private void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        gameObject.GetComponent<PlayerInputManager>().interact = false;
        playerInventory = GetComponent<PlayerInventory>();
        playerInputManager.OnInteract += PlayerInputManager_OnInteract;
    }

    void Start()
    {

    }

    void Update()
    {
        IInteractables interactable = GetInteractableObjects();
        if(interactable == null)
        {
            canInteract = false;
            return;
        }
        //print(player.GetComponent<PlayerInputManager>().interact);
        //InteractWithWeapon();
    }

    /*private GameObject InteractWithWeapon()
    {
        foreach (GameObject weapon in WeaponsManager.instance.Weapon)
        {
            weaponItem = weapon;
           
            if (gameObject.GetComponent<PlayerInputManager>().interact == true)
            {
                if (Vector3.Distance(weaponItem.transform.position, transform.position) < 1.5f)
                {
                    if (weaponItem.CompareTag("Sword") && weaponItem.activeSelf == true)
                    {
                        print("Pick up sword");
                        //playerInventory.AddItemToInventory(weaponItem);
                        gameObject.GetComponent<PlayerInputManager>().interact = false;
                        break;
                    }

                    if (weaponItem.CompareTag("Axe") && weaponItem.activeSelf == true)
                    {
                        print("Pick up axe");
                        //playerInventory.AddItemToInventory(weaponItem);
                        gameObject.GetComponent<PlayerInputManager>().interact = false;
                        break;
                    }

                    if (weaponItem.CompareTag("Dagger") && weaponItem.activeSelf == true)
                    {
                        print("Pick up dagger");
                        //playerInventory.AddItemToInventory(weaponItem);
                        gameObject.GetComponent<PlayerInputManager>().interact = false;
                        break;
                    }
                }
            }
        }

        gameObject.GetComponent<PlayerInputManager>().interact = false;
        return weaponItem;
    }*/

    /*private void AddItemToInventory(GameObject weaponObject)
    {
        if (weaponSlot.childCount >= 1)
        {
            weaponObject.tag = player.tag + weaponItem.tag;
            player.GetComponent<PlayerInventory>().ItemInventory.Add(weaponObject);
            weaponItem.SetActive(false);
        }
        else
        {
            weaponObject.tag = player.tag + weaponItem.tag;
            weaponObject.name = player.tag + weaponItem.tag;
            weaponObject.transform.position = weaponSlot.transform.position;
            weaponObject.transform.rotation = weaponSlot.transform.rotation;
            weaponObject.transform.SetParent(weaponSlot);
            weaponObject.SetActive(true);
        }
    }

    private void PlayerEquipAndSwitchWeapon()
    {
        player.GetComponent<PlayerInventory>().ItemInventory.IndexOf(weaponItem);
    }*/


    private void PlayerInputManager_OnInteract(object sender, System.EventArgs e)
    {
        IInteractables interactable = GetInteractableObjects();
        if(interactable != null)
        {
            canInteract = true;
            interactable.Interact(transform);
        }
        else if(interactable == null)
        {
            canInteract = false;
            return;
        }
    }


    public IInteractables GetInteractableObjects()
    {
        // Creating a list to cycle through all the interactable objects that the player is colliding with and adding said colliders to the list
        List<IInteractables> interactablesList = new List<IInteractables>();
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, sphereRadius);
        foreach (Collider hit in hitColliders)
        {
            if (hit.TryGetComponent(out IInteractables interactable))
            {
                interactablesList.Add(interactable);
            }
        }

        // Iterating through the above list again and checking for closest object
        // Checking if first object is found and setting it to the closest if so
        // Comparing if the new object is closer than previous closest, and if so, setting it as the new closest object to interact with
        // Return the new closest object
        IInteractables closestInteractableNPC = null;
        foreach(IInteractables interactable in interactablesList)
        {
            if (closestInteractableNPC == null)
            {
                closestInteractableNPC = interactable;
            }

            else if(Vector3.Distance(transform.position, interactable.GetInteractionTransform().position) 
                < Vector3.Distance(transform.position, closestInteractableNPC.GetInteractionTransform().position))
            {
                closestInteractableNPC = interactable;
            }
        }
        return closestInteractableNPC;
    }

    public bool GetCanInteractBool()
    {
        return canInteract;
    }
}
