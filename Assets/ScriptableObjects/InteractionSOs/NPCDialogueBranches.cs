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

    [SerializeField] bool keepConditionActive;
    public DialogueConditionTest conditionClone { get; private set; }

    public DialogueConditionTest condition;
    public int conditionIndex;

    private InteractionTextManagerSO dialogueManager;
    private ConditionSpawner conditionSpawner;


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

        if (conditionFulfilled)
        {
            dialogueManager.SetDialoguBranch(this); // Try adding the new dialogue variables on the choice test
        }

        if(dialogueManager.currentActiveDialogue != this)
        {
            conditionClone.SetDialogueConditionToFalse();
            DisableCondition();
        }
    }
    public void EnableCondition()
    {
        conditionClone.gameObject.SetActive(true);
    }

    public void DisableCondition()
    {
        conditionClone.SetDialogueConditionToFalse();
        if (!keepConditionActive)
        {
            conditionClone.gameObject.SetActive(false);
            //conditionClone.SetConditionMetToFalse(conditionSpawner.npc);
            return;
        }
    }
}
