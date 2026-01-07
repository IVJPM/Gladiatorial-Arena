using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractionTextManagerSO", menuName = "InteractionTextSO/InteractionDialogue")]

public class InteractionTextManagerSO : ScriptableObject
{
    [Header("Dialogue Options")]
    [SerializeField] string npcName;
    public List<string> greetingDialogue;
    [TextArea(3, 10)]
    public List<string> characterDialogue;
    public List<NPCDialogueBranches> npcDialogue;
    public NPCDialogueBranches currentActiveDialogue;
    public Transform NPC;
    public bool switchDialogue;

    public List<string> CharacterDialogue(NPCInteractions npc)
    {
        characterDialogue = greetingDialogue;
        GrabCurrentDialogueBranch();
        foreach (NPCDialogueBranches dialogueBranches in npcDialogue)
        {
            if (dialogueBranches.condition != null) //Checking if the branches have conditions that will need to be met in order to switch to a different set of dialogue
            {
                dialogueBranches.DialogueCondition();
            }
            else
            {
                characterDialogue = greetingDialogue;
            }
        }
        return characterDialogue;
    }
    
    public void ResetDialogue()
    {
        currentActiveDialogue.conditionClone.SetDialogueConditionToFalse();
        currentActiveDialogue = npcDialogue[0];
    }
    public bool SwitchDialogue()
    {
        return switchDialogue;
    }

    private void GrabCurrentDialogueBranch()
    {
        foreach(NPCDialogueBranches branch in npcDialogue)
        {
            branch.SetDialogueBranchParent(this);
        }
    }

    public NPCDialogueBranches SetDialoguBranch(NPCDialogueBranches branch)
    {
        currentActiveDialogue = branch;
        if(currentActiveDialogue.conditionFulfilled)
        {
            switchDialogue = true;
        }
        characterDialogue = currentActiveDialogue.dialogue;

        return currentActiveDialogue;
    }
}
