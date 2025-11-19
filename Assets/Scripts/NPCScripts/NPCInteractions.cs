using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.UI;
using UnityEditor.Rendering;

public class NPCInteractions : MonoBehaviour, IInteractables
{
    [SerializeField] public int currentDialogueIndex;
    [SerializeField] int questCompleteDialogue;
    [SerializeField] bool isInteracting;
    [SerializeField] string interactionButtonText;

    [SerializeField] List<string> newInteractionDialogue;
    [SerializeField] public List<string> characterDialogue;
    [SerializeField] InteractionTextManagerSO interactionTextManagerSO;

    public TextMeshProUGUI interactionDialogue;
    private Transform interactionTarget;

    private void Start()
    {
        if(interactionTextManagerSO != null)
        {
            //interactionTextManagerSO.SetParentNPC(this);
            characterDialogue = interactionTextManagerSO.CharacterDialogue(this);
            currentDialogueIndex = 0;
        }
        else
        {
            return;
        }
    }


    public virtual void Interact(Transform interactorTransform)
    {
        NpcDialogue(interactorTransform);
        
        /*if(interactionTextManagerSO.currentActiveDialogue != null)
        {
            if (currentDialogueIndex == interactionTextManagerSO.currentActiveDialogue.conditionIndex)
            {
                interactionTextManagerSO.currentActiveDialogue.EnableCondition();
            }
        }
        else
        {
            print("n");
            return;
        }*/

        /*for(int i = 0; i < interactionTextManagerSO.npcDialogue.Count; i++)
        {
            if(interactionTextManagerSO.npcDialogue[i] != null)
            {
                if (interactionTextManagerSO.npcDialogue[i] == interactionTextManagerSO.currentActiveDialogue && currentDialogueIndex == interactionTextManagerSO.currentActiveDialogue.conditionIndex)
                {
                    interactionTextManagerSO.currentActiveDialogue.EnableCondition();
                }
            }
        }*/
    }

    private void NpcDialogue(Transform interactorTransform)
    {
        print(currentDialogueIndex);
        //characterDialogue = interactionTextManagerSO.CharacterDialogue();

        interactionTarget = interactorTransform;

        if (!interactionDialogue.isActiveAndEnabled || interactionTextManagerSO.SwitchDialogue()) // Create 'PlayFromBeginning()' function to find a way to restart dialogue without exiting current conversattion first?
        {                                                                                         // Also create function to display dialogue based on different actions (open merchant menu, finish final dialogue, etc.) 
                                                                                                  // without having to manually press the dialogue action button
            characterDialogue = interactionTextManagerSO.CharacterDialogue(this);
            isInteracting = true;
            currentDialogueIndex = 0;
            interactionTextManagerSO.switchDialogue = false;
        }

        if (currentDialogueIndex < characterDialogue.Count && interactionDialogue.enabled)
        {
            interactionDialogue.text = characterDialogue[currentDialogueIndex];
            currentDialogueIndex++;
        }
        else if (currentDialogueIndex > characterDialogue.Count - 1 && interactionDialogue.isActiveAndEnabled)
        {
            //characterDialogue = interactionTextManagerSO.CharacterDialogue();
            currentDialogueIndex = 0;
            isInteracting = false;
        }
    }

    private void Update()
    {
        //SetNPCDialogue();

            if (interactionTarget != null)
        {
            if (Vector3.Distance(transform.position, interactionTarget.position) > 3f)
            {
                isInteracting = false;
            }
        }
        else
        {
            return;
        }

        //interactionTextManagerSO.CheckNPCIndex(this);
    }

    /*private void SetNPCDialogue()
    {
        TryGetComponent(out QuestGiver questGiver);
        if(questGiver != null)
        {
            if (!questGiver.QuestAssigned && !questGiver.FinishedQuest)
            {
                interactionDialogue.text = interactionTextManagerSO.InitialMeetingDialogue(initialNpcDialogue);

                questGiver.AssignQuest();
            }
            else if (questGiver.QuestAssigned && !questGiver.FinishedQuest)
            {
                questGiver.CheckAssignedQuestStatus();
            }
            else
            {
                interactionTextManagerSO.npcDialogue = interactionTextManagerSO.AdjustDialogueOptions(newInteractionDialogue);
            }
        }
        else
        {
            return;
        }
    }*/
    public string GetInteractionText()
    {
        return interactionButtonText;
    }

    public Transform GetInteractionTransform()
    {
        return transform;
    }

    public bool IsInteracting()
    {   
        return isInteracting;
    }
}
