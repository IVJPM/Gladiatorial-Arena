using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamageCollider : MonoBehaviour
{
    public Collider weaponCollider;
    public int weaponDamage;
    // Start is called before the first frame update
    void Awake()
    {
        weaponCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterStats damageTarget = other.GetComponent<CharacterStats>();
        
        if (damageTarget != null && damageTarget.invincibilityFrames == false && damageTarget.currentHealth > 0)
        {
            SoundFXManager.Instance.CollisionSoundFX(damageTarget.GetComponent<AudioSource>(), damageTarget.takeDamageAudio, .15f);
            damageTarget.CharacterTakeDamage(weaponDamage);
        }
    }
     
    public void EnableWeaponCollider()
    {
        weaponCollider.enabled = true;
    }

    public void DisableWeaponCollider()
    {
        weaponCollider.enabled = false;
    }
}
