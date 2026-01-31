using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObjective : MonoBehaviour, IObjectives
{
    [SerializeField] List<CharacterStats> enemyStats;
    [SerializeField] int killGoalNumber;
    [SerializeField] int killGoalCount;
    [SerializeField] bool objectiveComplete;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < enemyStats.Count; i++)
        {
            enemyStats[i].OnCharacterDeath += KillObjective_OnCharacterDeath; ;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void KillObjective_OnCharacterDeath(object sender, EventArgs e)
    {
        killGoalCount++;
        for (int i = 0; i < enemyStats.Count; i++)
        {
            if (enemyStats[i].currentHealth <= 0)
            {
                EvaluateObjectiveProgress();
                enemyStats[i].OnCharacterDeath -= KillObjective_OnCharacterDeath;
            }
        }
    }

    public void BeginObjective(Objective objective)
    {
        ObjectiveTracker.Instance.AddObjective(objective);
        objective.SetObjectiveStartedToTrue();
    }

    public void EvaluateObjectiveProgress()
    {
        if(killGoalCount >= killGoalNumber)
        {
            objectiveComplete = true;
        }
        else
        {
            objectiveComplete = false; 
        }
    }

    public void CompleteObjective(Objective objective)
    {
        ObjectiveTracker.Instance.CompletedObjectives(objective);
    }

    public bool ObjectiveCompletion()
    {
        return objectiveComplete;
    }
}
