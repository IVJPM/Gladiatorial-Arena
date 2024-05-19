using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] HpManagerSO hpManagerSo;

    private void Start()
    {
        HealthSliderValue(hpManagerSo.HP);
    }

    private void OnEnable()
    {
        hpManagerSo.HPchangeEvent.AddListener(HealthSliderValue);
    }

    private void OnDisable()
    {
        hpManagerSo.HPchangeEvent.RemoveListener(HealthSliderValue);
    }

    // This funciton is run when HpManagerSO.HPchangeEvent event is fired in OnEnable()
    private void HealthSliderValue(int healthAmount) 
    {
        slider.value = healthAmount;
    }
}
