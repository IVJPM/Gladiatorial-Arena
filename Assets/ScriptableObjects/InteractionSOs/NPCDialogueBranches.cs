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

        if (conditionFulfilled)
        {
            dialogueManager.SetDialoguBranch(this);
        }
    }

    public void EnableCondition(int dialogueIndex)
    {
        if(condition != null)
        {
            for (dialogueIndex = 0; dialogueIndex < dialogue.Count; dialogueIndex++)
            {
                if (dialogueIndex == conditionIndex - 1)
                {
                    condition.enabled = true;
                    Debug.Log("I'm done talking now");
                }
            }
        }
        else
        {
            return;
        }
    }

    public DialogueConditionTest CheckForCondition()
    {
        if( condition != null )
        {
            return condition;
        }
        else
        {
            return null;
        }
    }
}
