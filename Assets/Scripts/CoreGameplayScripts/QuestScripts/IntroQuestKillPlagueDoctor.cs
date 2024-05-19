using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroQuestKillPlagueDoctor : Quest
{
    private void Start()
    {
        questName = "Faceless Man";
        questDescription = "Kill the plague doctor who stole the man's face!";

        questGoals.Add(new KillQuestGoal(this, "Plague Doctor", "Kill the plague doctor.", false, 0, 1));

        questGoals.ForEach(goal => goal.BeginQuest());
    }

}
