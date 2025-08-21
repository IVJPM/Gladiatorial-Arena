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
    public DialogueConditionTest conditionClone;


    public void SetDialogueBranchParent(InteractionTextManagerSO dialogueManager)
    {
        this.dialogueManager = dialogueManager;
    }

    public void DialogueCondition()
    {
        conditionFulfilled = conditionClone.conditionMet;

        if (conditionFulfilled)
        {
            //if(conditionClone.TryGetComponent(out DialogueConditionTest newDialogue))
            dialogueManager.SetDialoguBranch(this); // Try adding the new dialogue variables on the choice test
        }
    }

    public void EnableCondition()
    {
        if(conditionClone != null)
        {
            for (int i = 0; i < dialogue.Count; i++)
            {
                if (i == conditionIndex - 1)
                {
                    Debug.Log(conditionClone);
                    conditionClone.gameObject.SetActive(true);
                    Debug.Log("I'm done talking now");
                }
            }
        }
        else
        {
            return;
        }
    }

    public void CreateConditions()
    {
        
            //conditionClone = Instantiate(condition, dialogueManager.NPC);
            //conditionClone.gameObject.SetActive(false);
        if(condition.TryGetComponent(out ConditionChoiceTest conditionTest))
        {
            conditionClone = conditionTest.InstantiateCondition(dialogueManager.NPC);
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
