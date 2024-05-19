using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerManager : MonoBehaviour, IWeapons
{

    new Collider collider;

    [SerializeField] int baseDaggerDamage;
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
        return baseDaggerDamage;
    }

    public void EnableWeaponCollider()
    {
        collider.enabled = true;
    }

    public void DisableWeaponCollider()
    {
        collider.enabled = false;
    }
}
