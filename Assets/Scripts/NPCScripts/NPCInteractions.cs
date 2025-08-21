using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.UI;
using UnityEditor.Rendering;

public class NPCInteractions : MonoBehaviour, IInteractables
{
    [SerializeField] int currentDialogueIndex;
    [SerializeField] int questCompleteDialogue;
    [SerializeField] bool isInteracting;
    [SerializeField] string interactionButtonText;

    [SerializeField] List<string> newInteractionDialogue;
    [SerializeField] List<string> characterDialogue;
    [SerializeField] InteractionTextManagerSO interactionTextManagerSO;

    public TextMeshProUGUI interactionDialogue;
    private Transform interactionTarget;

    private void Awake()
    {
        if(interactionTextManagerSO != null)
        {
            interactionTextManagerSO.SetParentNPC(this);
            characterDialogue = interactionTextManagerSO.CharacterDialogue();
            currentDialogueIndex = 0;
        }
        else
        {
            return;
        }
    }
    public virtual void Interact(Transform interactorTransform)
    {
        characterDialogue = interactionTextManagerSO.CharacterDialogue();

        interactionTarget = interactorTransform;


        if (!interactionDialogue.isActiveAndEnabled)
        {
            isInteracting = true;
            currentDialogueIndex = 0;
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
