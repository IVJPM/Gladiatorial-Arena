using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueConditionObjects : MonoBehaviour
{
    [SerializeField] List<DialogueConditionTest> conditions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //conditions = GetComponentsInChildren<DialogueConditionTest>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
