using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTester : MonoBehaviour
{
    public enum ObjectiveType { Kill, Retrieve }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Task newTask = new Task();
        //newTask.SetTask(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
