using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    // public string itemName = "Items";
     public List<GameObject> ItemInventory = new List<GameObject>();
     private GameObject item;
     [SerializeField] Transform weaponSlot;
     [SerializeField] PlayerInteractables playerInteractables;
    PlayerInputManager playerInputManager;
    [SerializeField] float sphereRadius;
    public float maxDistance;
    [SerializeField] LayerMask itemLayerMask;

   
    private void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        //playerInteractables = GetComponent<PlayerInteractables>();
        playerInputManager.OnInteract += PlayerInputManager_OnInteract;
    }

    private void FixedUpdate()
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
                AddItemToInventory(hit.gameObject);
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

   
}
