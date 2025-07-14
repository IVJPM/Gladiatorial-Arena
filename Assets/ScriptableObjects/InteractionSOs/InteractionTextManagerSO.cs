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
    // [field: SerializeField] public string dialogueOptions {  get; private set; }
    [TextArea(3, 10)]
    public List<string> characterDialogue;
    public List<NPCDialogueBranches> npcDialogue;


    public int dialogueBranchIndex = 0;

    public List<string> AdjustDialogueOptions(List<string> dialogueOptions)
    {
        return dialogueOptions;
    }

    public List<string> CharacterDialogue()
    {
        characterDialogue = greetingDialogue;
        GrabCurrentDialogueBranch();

        foreach(NPCDialogueBranches dialogueBranches in npcDialogue)
        {
            if(dialogueBranches.condition != null)
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

    public void SetDialoguBranch(NPCDialogueBranches branch)
    {
        characterDialogue = branch.dialogue;
    }
}
