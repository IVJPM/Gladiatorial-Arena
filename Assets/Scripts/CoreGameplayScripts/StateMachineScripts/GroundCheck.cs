using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] BoxCollider ground;
    [SerializeField] LayerMask groundMask;

    public bool isGrounded { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckGroundState();
        //Debug.Log(isGrounded);
    }

    public void CheckGroundState()
    {
        isGrounded = Physics.OverlapCapsule(ground.bounds.min, ground.bounds.max, groundMask).Length > 0;
    }
}
