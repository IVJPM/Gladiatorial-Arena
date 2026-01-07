using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCInteractions : MonoBehaviour, IInteractables
{
    public event EventHandler OnDialogueSet;

    [field:SerializeField] public int currentDialogueIndex {  get; private set; }
    [SerializeField] int questCompleteDialogue;
    [SerializeField] bool isInteracting;
    [SerializeField] string interactionButtonText;

    [SerializeField] public List<string> characterDialogue;
    [SerializeField] InteractionTextManagerSO interactionTextManagerSO;

    public TextMeshProUGUI interactionDialogue;
    private Transform interactionTarget;

    private void Start()
    {
        if(interactionTextManagerSO != null)
        {
            characterDialogue = interactionTextManagerSO.CharacterDialogue(this);
            currentDialogueIndex = 0;
        }
        else
        {
            return;
        }
    }

    public int GetCurrentDialogueIndex()
    {
        return currentDialogueIndex; 
    }

    public virtual void Interact(Transform interactorTransform)
    {
        NpcDialogue(interactorTransform);
        if(interactionTextManagerSO.currentActiveDialogue != null && interactionTextManagerSO.currentActiveDialogue.conditionIndex == currentDialogueIndex)
        {
            interactionTextManagerSO.currentActiveDialogue.EnableCondition();
        }
        else if(interactionTextManagerSO.currentActiveDialogue == null)
        {
            return;
        }
        else
        {
            interactionTextManagerSO.currentActiveDialogue.DisableCondition();
        }
    }

    private void NpcDialogue(Transform interactorTransform)
    {
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
                if (interactionTextManagerSO.currentActiveDialogue != null)
                {
                    currentDialogueIndex = 0;
                    interactionTextManagerSO.ResetDialogue();
                    OnDialogueSet?.Invoke(this, EventArgs.Empty);
                    //interactionTextManagerSO.currentActiveDialogue.DisableCondition();
                }
                else
                {
                    return;
                }
                    isInteracting = false;
            }
        }
        else
        {
            return;
        }
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
