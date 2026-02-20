using System;
using UnityEngine;

public class RetrieveObjective : MonoBehaviour, IObjectives
{
    event EventHandler IObjectives.OnObjectiveUpdate
    {
        add
        {
            throw new NotImplementedException();
        }

        remove
        {
            throw new NotImplementedException();
        }
    }

    public void BeginObjective(Objective objective)
    {
        throw new System.NotImplementedException();
    }

    public void CompleteObjective(Objective objective)
    {
        throw new System.NotImplementedException();
    }

    public void EvaluateObjectiveProgress(Task task)
    {
        throw new System.NotImplementedException();
    }

    public bool ObjectiveCompletion()
    {
        throw new System.NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
