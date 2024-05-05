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
    [SerializeField] InteractionTextManagerSO interactionTextManagerSO;

    public void Interact(Transform interactorTransform)
    {
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
