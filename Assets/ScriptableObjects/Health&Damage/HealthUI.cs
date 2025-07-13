using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Slider slider;

    private void Start()
    {
        
    }

   
    public void MaxHealthAmount(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
    public void CurrentHealthAmount(int healthAmount) 
    {
        slider.value = healthAmount;
    }
}
