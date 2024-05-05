using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform weaponSlot;
    private Animator animator;
    int layerIndex = 1;
    float layerWeight = 1;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        AttackTarget();
    }

    private void AttackTarget()
    {
        float attackDistance = Vector3.Distance(transform.position, target.position);

        if(attackDistance < 2f)
        {
            animator.SetLayerWeight(layerIndex, layerWeight);
            animator.SetTrigger("attack");
            weaponSlot.GetChild(0).GetComponent<Collider>().enabled = true;
        }

        else
        {
            animator.SetLayerWeight(0, 0);
            weaponSlot.GetChild(0).GetComponent<Collider>().enabled = false;
        }
    }
}
