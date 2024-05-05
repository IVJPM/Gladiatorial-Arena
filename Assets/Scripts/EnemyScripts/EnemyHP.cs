using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Slider slider;

    private void Update()
    {
        
    }

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
    public void SetCurrentHealth(int currentHealth)
    {
        slider.value = currentHealth;
    }
}
