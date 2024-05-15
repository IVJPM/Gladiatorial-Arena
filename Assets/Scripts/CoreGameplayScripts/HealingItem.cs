using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    [SerializeField] int healAmount;
    
    public int ItemHealAmount()
    {
        return healAmount;
    }
}
