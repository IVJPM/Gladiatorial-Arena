using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCDialogueBranches", menuName = "NPCDialogue/NPCDialogueBranches")]
public class NPCDialogueBranches : ScriptableObject
{
    [TextArea(3, 10)]
    public List<string> dialogue;
    [field:SerializeField] public bool conditionFulfilled {  get; private set; }

    private InteractionTextManagerSO dialogueManager;
    public DialogueConditionTest condition;
    public void SetDialogueBranchParent(InteractionTextManagerSO dialogueManager)
    {
        this.dialogueManager = dialogueManager;
    }

    public void DialogueCondition()
    {
        conditionFulfilled = condition.conditionMet;
        if(conditionFulfilled)
        {
            condition.CreateDialogueCondition();
            dialogueManager.SetDialoguBranch(this);
        }
    }
}
