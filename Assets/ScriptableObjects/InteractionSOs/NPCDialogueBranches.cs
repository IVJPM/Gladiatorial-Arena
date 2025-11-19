using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCDialogueBranches", menuName = "NPCDialogue/NPCDialogueBranches")]
public class NPCDialogueBranches : ScriptableObject
{
    [Header("Dialogue")]
    [TextArea(3, 10)]
    public List<string> dialogue;
    
    [field:SerializeField] public bool conditionFulfilled { get; private set; }

    public int conditionIndex;

    private InteractionTextManagerSO dialogueManager;
    public DialogueConditionTest condition;
    public DialogueConditionTest conditionClone;
    [SerializeField] ConditionSpawner conditionSpawner;


    public void SetDialogueBranchParent(InteractionTextManagerSO dialogueManager)
    {
        this.dialogueManager = dialogueManager;
    }

    public void SetConditionSpawner(ConditionSpawner conditionSpawnerRoot)
    {
        conditionSpawner = conditionSpawnerRoot;

        for (int i = 0; i < conditionSpawner.conditionClone.Count; i++)
        {
            if (conditionSpawner.dialogueBranches[i] == this)
            {
                conditionClone = conditionSpawner.conditionClone[i];
            }
        }
    }

    public void DialogueCondition()
    {
        conditionFulfilled = conditionClone.conditionMet;
        //conditionClone.SetConditionActive(this);

        if (conditionFulfilled)
        {
            //if(conditionClone.TryGetComponent(out DialogueConditionTest newDialogue))
            dialogueManager.SetDialoguBranch(this); // Try adding the new dialogue variables on the choice test
        }
    }

    public void EnableCondition()
    {
        conditionClone.gameObject.SetActive(true);
    }

    public void CreateConditions()
    {
        //conditionClone = condition.InstantiateCondition(dialogueManager.NPC);
        //conditionClone.gameObject.SetActive(true);
    }
    /*public DialogueConditionTest CheckForCondition()
    {
        if( condition != null )
        {
            return condition;
        }
        else
        {
            return null;
        }
    }*/
}
