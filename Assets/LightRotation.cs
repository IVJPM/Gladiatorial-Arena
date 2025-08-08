using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LightRotation : MonoBehaviour
{
    [SerializeField] Terrain terrain;
    [SerializeField] float lightAngle;
    void Start()
    {

    }

    void Update()
    {
        transform.RotateAround(terrain.transform.position, Vector3.up, lightAngle);
    }
}
