using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCDialogueBranches", menuName = "NPCDialogue/NPCDialogueBranches")]
public class NPCDialogueBranches : ScriptableObject
{
    [TextArea(3, 10)]
    public List<string> dialogue;
    [field:SerializeField] public bool conditionFulfilled { get; private set; }

    public int conditionIndex;

    private InteractionTextManagerSO dialogueManager;
    public DialogueConditionTest condition;
    public void SetDialogueBranchParent(InteractionTextManagerSO dialogueManager)
    {
        this.dialogueManager = dialogueManager;
    }

    public void DialogueCondition()
    {
        conditionFulfilled = condition.conditionMet;

        /*ConditionStruct conditionStruct = new ConditionStruct();
        conditionStruct.CreateCondition(condition, condition.characterReply);*/

        if (conditionFulfilled)
        {
            dialogueManager.SetDialoguBranch(this);
        }
    }

    public void EnableCondition(int dialogueIndex)
    {
        for (dialogueIndex = 0; dialogueIndex < dialogue.Count; dialogueIndex++)
        {
            if (dialogueIndex == dialogue.Count - 1)
            {
                Debug.Log("I'm done talking now");
            }
        }
    }
}
