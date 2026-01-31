using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTracker : MonoBehaviour
{
    public static ObjectiveTracker Instance;

    [SerializeField] List<Objective> initialisedObjectives;
    [SerializeField] List<Objective> completedObjectives;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
       if (Instance != null)
       {
           Destroy(Instance);
       }
       else
       {
           Instance = this;
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddObjective(Objective objective)
    {
        if(!initialisedObjectives.Contains(objective))
        {
            initialisedObjectives.Add(objective);
        }
        else
        {
            return;
        }
    }

    public void CompletedObjectives(Objective objective)
    {
        if(initialisedObjectives.Contains(objective) && !completedObjectives.Contains(objective))
        {
            completedObjectives.Add(objective);
        }
        else
        {
            return;
        }
    }
}
