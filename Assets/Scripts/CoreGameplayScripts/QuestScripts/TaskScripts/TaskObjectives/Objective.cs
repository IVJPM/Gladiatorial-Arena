using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public event EventHandler OnObjectiveStarted;


    [SerializeField] List<Task> task = new List<Task>();
    [SerializeField] int maxTasks;
    [SerializeField] bool objectiveStarted;
    [SerializeField] bool objectiveFinished;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        for(int i  = 0; i < maxTasks; i++)
        {
            //task.Add(new Task());
            task[i].OnTaskCompletion += Objective_OnTaskCompletion;
            task[i].SetTask(this);
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

            if (!task[i].taskCompletion)
            {
                objectiveFinished = false;
                return;
            }
            else
            {
                task[i].OnTaskCompletion -= Objective_OnTaskCompletion;
                objectiveFinished = true;
            }
        }
    }
}
