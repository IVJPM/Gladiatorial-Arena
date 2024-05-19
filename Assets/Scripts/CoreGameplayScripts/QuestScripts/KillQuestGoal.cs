using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class KillQuestGoal : QuestBaseInfo
{
    public string enemyName {  get; private set; }
    public int killGoalAmount { get; private set; }
    
    public KillQuestGoal (Quest quest, string enemyName, string questDescription, bool questComplete, int currentGoalAmount, int requiredGoalAmount)
    {
        this.quest = quest;
        this.enemyName = enemyName;
        this.questDescription = questDescription;
        this.questComplete = questComplete;
        this.currentGoalAmount = currentGoalAmount;
        this.requiredGoalAmount = requiredGoalAmount;
    }

    public override void BeginQuest()
    {
        base.BeginQuest();
        EnemyTakeDamage.OnEnemyDeath += EnemyTakeDamage_OnEnemyDeath;
    }
    private void EnemyTakeDamage_OnEnemyDeath(object sender, System.EventArgs e)
    {
        EnemyKilled(enemyName);
        Debug.Log(enemyName + " killed");
    }


    private void EnemyKilled(string enemyName)
    {
        if(enemyName == this.enemyName)
        {
             this.currentGoalAmount++;
            EvaluateQuestStatus();
            Debug.Log(currentGoalAmount);
        }
    }


}
