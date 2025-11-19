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
        if(npc.currentDialogueIndex == dialogueIndex - 1)
        {
            Debug.Log("d");
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
        /*for (int i = 0; i < npcDialogue.dialogue.Count; i++)
        {
            if (npcDialogue.dialogue.IndexOf(npcDialogue.dialogue[i]) == dialogueIndex - 1)
            {
                print("d");
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }*/
    }
}
