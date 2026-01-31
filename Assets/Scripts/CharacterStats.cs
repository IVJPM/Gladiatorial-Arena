using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStats : MonoBehaviour
{
    public event EventHandler OnCharacterDeath;
    public bool invincibilityFrames { get; private set; }

    public int characterHealthLevel;
    public int maxHealth;
    public int currentHealth;
    public AudioClip takeDamageAudio;

    public HealthUI healthUI;
    private void Start()
    {
        maxHealth = MaxHealthAmountCalculation();
        healthUI.MaxHealthAmount(maxHealth);
        currentHealth = maxHealth;
    }

    public int MaxHealthAmountCalculation()
    {
        maxHealth = characterHealthLevel * 5;
        return maxHealth;
    }
    public void CharacterTakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            OnCharacterDeath?.Invoke(this, EventArgs.Empty);
        }
        healthUI.CurrentHealthAmount(currentHealth);
    }

    public void EnableInvincibilityFrames()
    {
        invincibilityFrames = true;
    }

    public void DisableInvincibilityFrames()
    {
        invincibilityFrames = false;
    }
}
