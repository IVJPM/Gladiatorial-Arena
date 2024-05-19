using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    public static event EventHandler OnEnemyDeath;

    [SerializeField] WeaponsManagerSO weaponManagerSO;
    [SerializeField] HpManagerSO hpManagerSO;
    [SerializeField] LayerMask layerMask;
    [SerializeField] AudioClip getHit;

    AudioSource audioSource;
    private int damageValue;
    private void Update()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //This triggers the HpManagerSO.HPchangeEvent event
        if (other.gameObject.TryGetComponent(out IWeapons weapons))
        {
            damageValue = weapons.WeaponBaseDamage();

            if (((1<< other.gameObject.layer) & layerMask) != 0)
            {
                hpManagerSO.DamageHP(damageValue);
                print(damageValue);
            }
            if(hpManagerSO.HP <= 0)
            {
                OnEnemyDeath?.Invoke(this, EventArgs.Empty);
            }

            audioSource.pitch = 1f;
            audioSource.volume = .75f;
            audioSource.PlayOneShot(getHit);
        }
    }
}
