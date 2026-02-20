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

    public void InitiateTask(Objective objective)
    {
        objectiveType = test.GetComponent<IObjectives>();
        objectiveType.BeginObjective(objective);
        objectiveType.OnObjectiveUpdate += ObjectiveType_OnObjectiveUpdate;
    }

    private void ObjectiveType_OnObjectiveUpdate(object sender, EventArgs e)
    {
        OnTaskCompletion?.Invoke(this, EventArgs.Empty);
    }

    public void EvaluateQuestCompletion() // Flip this with the objectiveType
    {
        objectiveType.EvaluateObjectiveProgress(this);
    }
}
