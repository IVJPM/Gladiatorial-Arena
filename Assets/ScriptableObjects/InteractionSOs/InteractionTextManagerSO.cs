using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractionTextManagerSO", menuName = "InteractionTextSO/InteractionDialogue")]

public class InteractionTextManagerSO : ScriptableObject
{
    public event EventHandler OnSwitchDialogue;

    [Header("Dialogue Options")]
    [SerializeField] string npcName;
    public List<string> greetingDialogue;
    [TextArea(3, 10)]
    public List<string> characterDialogue;
    public List<NPCDialogueBranches> npcDialogue;
    public NPCDialogueBranches currentActiveDialogue;
    public Transform NPC;
    public int dialogueBranchIndex = 0;
    public bool switchDialogue;

    public void SetParentNPC()
    {
        for(int i = 0; i < npcDialogue.Count; i++)
        {
            npcDialogue[i].CreateConditions();
        }
        //NPC = npc.transform;
    }

    public void CreateDialogueBranchConditionClones(ConditionSpawner conditionSpawner)
    {
        for (int i = 0; i < npcDialogue.Count; i++)
        {
            if (npcDialogue[i].condition == conditionSpawner.conditionClone[i])
            {
                npcDialogue[i].conditionClone = conditionSpawner.conditionClone[i];
            }
        }
    }

    public List<string> CharacterDialogue(NPCInteractions npc)
    {
        dialogueBranchIndex = npc.currentDialogueIndex;
        //Debug.Log(dialogueBranchIndex);
        characterDialogue = greetingDialogue;
        GrabCurrentDialogueBranch();

        foreach(NPCDialogueBranches dialogueBranches in npcDialogue)
        {
            if (dialogueBranches.conditionClone != null) //Checking if the branches have conditions that will need to be met in order to switch to a different set of dialogue
            {
                dialogueBranches.DialogueCondition();
                //currentActiveDialogue.condition.SetConditionActive(npc);

                /*for(int i = 0; i < npc.characterDialogue.Count; i++)
                {
                    if(i == currentActiveDialogue.conditionClone.dialogueIndex - 1)
                    {
                        Debug.Log("d");
                    }
                }*/
                //ActivateCondition(dialogueBranches.condition);
            }
            else
            {
                characterDialogue = greetingDialogue;
            }
        }
        return characterDialogue;
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
