using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjectPractice", menuName = "Inventory/List")]


public class ScriptableObjectInventoryTest : ScriptableObject
{
    public string itemName = "Items";
    public List<GameObject> ItemInventory;
}

