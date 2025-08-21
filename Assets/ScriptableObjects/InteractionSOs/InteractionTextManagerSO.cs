using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public int dialogueBranchIndex = 0;

    public List<string> AdjustDialogueOptions(List<string> dialogueOptions)
    {
        return dialogueOptions;
    }

    public void SetParentNPC(NPCInteractions npc)
    {
        for(int i = 0; i < npcDialogue.Count; i++)
        {
            npcDialogue[i].CreateConditions();
        }
        NPC = npc.transform;
    }

    public List<string> CharacterDialogue()
    {
        characterDialogue = greetingDialogue;
        GrabCurrentDialogueBranch();

        foreach(NPCDialogueBranches dialogueBranches in npcDialogue)
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
        characterDialogue = currentActiveDialogue.dialogue;
        return currentActiveDialogue;
    }
}
