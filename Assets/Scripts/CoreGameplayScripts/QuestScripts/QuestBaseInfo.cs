using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBaseInfo
{
    public Quest quest { get; set; }
    public string questDescription { get;  set; }
    public int currentGoalAmount { get;  set; }
    public int requiredGoalAmount { get;  set; }
    public bool questComplete { get;  set; }
    public bool questIsActive { get;  set; }

    public virtual void BeginQuest()
    {

    }
    public void QuestComplete()
    {
        questComplete = true;
        quest.CheckGoals();
    }

    public void QuestActive()
    {

    }

    public void EvaluateQuestStatus()
    {
        if(currentGoalAmount >= requiredGoalAmount)
        {
            QuestComplete();
        }
        Debug.Log(questComplete);
    }
}
