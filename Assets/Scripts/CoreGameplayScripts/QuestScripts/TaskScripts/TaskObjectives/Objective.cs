using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public event EventHandler OnObjectiveStarted;
    public event EventHandler OnObjectiveFinished;


    [SerializeField] ObjectiveCondition objectiveCondition;

    [SerializeField] List<Task> task = new List<Task>();
    [SerializeField] int maxTasks;
    [SerializeField] bool objectiveStarted;
    [SerializeField] bool objectiveFinished;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
            objectiveCondition.AssignObjective(this);
    }

    private void Start()
    {
        for (int i = 0; i < maxTasks; i++)
        {
            task[i].OnTaskCompletion += Objective_OnTaskCompletion;
            task[i].InitiateTask(this);
        }
    }

    private void Objective_OnTaskCompletion(object sender, EventArgs e)
    {
        CompleteObjective();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetObjectiveStartedToTrue()
    {
        objectiveStarted = true;
        OnObjectiveStarted?.Invoke(this, EventArgs.Empty);
    }

    public void CompleteObjective()
    {
        for (int i = 0; i < task.Count; i++)
        {
            task[i].EvaluateQuestCompletion();

            if (task[i].taskCompletion)
            {
                objectiveFinished = true;
                OnObjectiveFinished?.Invoke(this, EventArgs.Empty);
                task[i].OnTaskCompletion -= Objective_OnTaskCompletion;
            }
            else
            {
                objectiveFinished = false;
            }
        }
    }

    public bool ObjectiveStarted()
    {
        return objectiveStarted; 
    }
}
