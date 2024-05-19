using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public bool QuestAssigned {  get; private set; }
    public bool FinishedQuest {  get; private set; }
    public Quest quest { get; private set; }

    [SerializeField] InteractionTextManagerSO interactionTextManagerSO;
    [SerializeField] GameObject quests;
    [SerializeField] string questType;

    public void AssignQuest()
    {
        QuestAssigned = true;
        quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
    }

    public void CheckAssignedQuestStatus()
    {
        if(quest.questIsDone)
        {
            quest.QuestReward();
            FinishedQuest = true;
            QuestAssigned = false;
           // interactionTextManagerSO.AdjustDialogueOptions("You got him!");
        }
    }
}
