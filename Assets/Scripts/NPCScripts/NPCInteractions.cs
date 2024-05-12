using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCInteractions : MonoBehaviour, IInteractables
{
    [SerializeField] int currentDialogue = 0;
    [SerializeField] bool isInteracting;
    [SerializeField] string interactionText;
    public TextMeshProUGUI interactionDialogue;
    private Transform interactionTarget;
    [SerializeField] InteractionTextManagerSO interactionTextManagerSO;

    public void Interact(Transform interactorTransform)
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
            Debug.Log(currentDialogue);
        }
        currentDialogue++;

        if(interactionDialogue.IsActive() == true && currentDialogue > interactionTextManagerSO.npcDialogue.Count)
        {
            isInteracting = false;
        }
    }

    private void Update()
    {
        if(interactionTarget != null)
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

    public string GetInteractionText()
    {
        return interactionText;
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
