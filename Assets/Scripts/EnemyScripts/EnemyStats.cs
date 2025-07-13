using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public static event EventHandler OnEnemyDeath;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = MaxHealthAmountCalculation();
        healthUI.MaxHealthAmount(maxHealth);
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            OnEnemyDeath?.Invoke(this, EventArgs.Empty);
        }
    }
}
