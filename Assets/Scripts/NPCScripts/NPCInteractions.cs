using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.Rendering.UI;

public class NPCInteractions : MonoBehaviour, IInteractables
{
    [SerializeField] int currentDialogue;
    [SerializeField] int questCompleteDialogue;
    [SerializeField] bool isInteracting;
    [SerializeField] string interactionButtonText;
    [SerializeField] string initialNpcDialogue;

    [SerializeField] List<string> newInteractionDialogue;
    [SerializeField] InteractionTextManagerSO interactionTextManagerSO;

    public TextMeshProUGUI interactionDialogue;
    private Transform interactionTarget;

    private void Awake()
    {
        interactionDialogue.text = interactionTextManagerSO.InitialMeetingDialogue(initialNpcDialogue);
        currentDialogue = 0;
    }


    public virtual void Interact(Transform interactorTransform)
    {

        interactionTarget = interactorTransform;
        if (interactionDialogue.IsActive() == false)
        {
            isInteracting = true;
            currentDialogue = 0;
        }
        if (currentDialogue < interactionTextManagerSO.npcDialogue.Count)
        {
            interactionDialogue.text = interactionTextManagerSO.npcDialogue[currentDialogue];
        }
        currentDialogue++;

        if(interactionDialogue.IsActive() == true && currentDialogue > interactionTextManagerSO.npcDialogue.Count)
        {
            isInteracting = false;
        }

    }

    private void Update()
    {
        SetNPCDialogue();

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

    private void SetNPCDialogue()
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
    }
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
