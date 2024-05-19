using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "HealthScriptableObject", menuName = "CharacterHealthPoints/HP")]
public class HpManagerSO : ScriptableObject
{
    public int maxHP = 100;

    public int HP;

    
    public UnityEvent<int> HPchangeEvent;
    private void OnEnable()
    {
        HP = maxHP;
        if(HPchangeEvent == null)
        {
            HPchangeEvent = new UnityEvent<int>();
        }
    }

    //When this function is triggered, the HpManagerSO.HPchangeEvent event will run
    public void DamageHP(int damageAmount)
    {
        HP -= damageAmount;
        if(HP <= 0)
        {
            HP = 0;
        }
        HPchangeEvent?.Invoke(HP);
    }

    public void HealHP(int healAmount)
    {
        if( HP <= maxHP)
        {
            HP += healAmount;
            if(HP >= maxHP)
            {
                HP = maxHP;
            }
            HPchangeEvent?.Invoke(HP);
        }
        
    }
}
