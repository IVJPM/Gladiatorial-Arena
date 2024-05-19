using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public List<QuestBaseInfo> questGoals { get; set; } = new List<QuestBaseInfo>();
    public string questName { get; set;}
    public string questDescription { get; set;}
    public bool questIsDone { get; set; }

    public void CheckGoals()
    {
        questIsDone = questGoals.All(goal => goal.questComplete);
    }

    public void QuestReward()
    {
        {
            Debug.Log("You killed the doctor! Shame about the guy's face, though...");
        }
    }
}
