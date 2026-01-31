using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public static event EventHandler OnEnemyDeath;
    public event EventHandler OnEnemyKilled;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = MaxHealthAmountCalculation();
        healthUI.MaxHealthAmount(maxHealth);
        currentHealth = maxHealth;

        OnEnemyKilled += EnemyStats_OnEnemyKilled;
    }

    private void EnemyStats_OnEnemyKilled(object sender, EventArgs e)
    {
        if(currentHealth <= 0)
        {
            OnEnemyKilled?.Invoke(this, EventArgs.Empty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            OnEnemyDeath?.Invoke(this, EventArgs.Empty);
            return;
        }
    }
}
