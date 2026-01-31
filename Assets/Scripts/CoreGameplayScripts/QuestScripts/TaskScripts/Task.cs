using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Task
{

    public event EventHandler OnTaskCompletion;

    public IObjectives objectiveType;
    public string taskDescription;
    public int objectiveTargets;
    public bool taskCompletion;

    public GameObject test;


    public void SetTask(Objective testObject)
    {
        //testObject.SetObjectiveStartedToTrue();
        Debug.Log(testObject.name);
    }

    public void InitiateTask(Objective objective)
    {
        OnTaskCompletion += Task_OnTaskCompletion;
        objectiveType = test.GetComponent<IObjectives>();
        objectiveType.BeginObjective(objective);
    }

    private void Task_OnTaskCompletion(object sender, EventArgs e)
    {
        if(objectiveType.ObjectiveCompletion())
        {
            OnTaskCompletion?.Invoke(this, EventArgs.Empty);
        }
    }

    public void EvaluateQuestCompletion() // Flip this with the objectiveType
    {
        objectiveType.EvaluateObjectiveProgress();
    }
}
