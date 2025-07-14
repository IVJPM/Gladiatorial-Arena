using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour, IWeapons
{
    new Collider collider;

    [SerializeField] int baseSwordDamage;
    [SerializeField] GameObject swordWeaponModel;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int WeaponBaseDamage()
    {
        return baseSwordDamage;
    }

    public void EnableWeaponCollider()
    {
        swordWeaponModel.GetComponent<Collider>().enabled = true;
    }

    public void DisableWeaponCollider()
    {
        swordWeaponModel.GetComponent<Collider>().enabled = false;
    }
}
