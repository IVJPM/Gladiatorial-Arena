using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogueConditionTest : MonoBehaviour
{
    public bool conditionMet;
    public int dialogueIndex;

    public virtual void CreateDialogueCondition()
    {

    }

    public DialogueConditionTest InstantiateCondition(Transform NpcParentObject)
    {
        DialogueConditionTest newConditionClone = Instantiate(this, NpcParentObject.gameObject.transform);
        return newConditionClone;
    }

    public virtual void SetConditionActive(/*NPCDialogueBranches npcDialogue*/ NPCInteractions npc) // Try moving to the NPCDialogueBranches script to be able to access the NPCInteractions variables
    {
        if(npc.currentDialogueIndex == dialogueIndex)
        {
            Debug.Log("d");
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public virtual void SetConditionMetToFalse(NPCInteractions npcInteractor)
    {
        if (conditionMet || !npcInteractor.IsInteracting())
        {
            conditionMet = false;
        }
    }

    public void SetDialogueConditionToFalse()
    {
        //gameObject.SetActive(false);
        conditionMet = false;
    }
}
