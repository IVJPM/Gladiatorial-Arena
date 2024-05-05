using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class PlayerInteractionsUI : MonoBehaviour
{
    // Will be placed on a Canvas to show interaction texts between player and other objects
    [SerializeField] GameObject canvasInteractionContainer;
    [SerializeField] GameObject dialogueInteractionContainer;
    [SerializeField] PlayerInteractables playerInteractables;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    private void Update()
    {
        if (playerInteractables.GetInteractableObjects() != null)
        {
            ShowInteractionText(playerInteractables.GetInteractableObjects());
        }
        else 
        {
            HideInteractionText(playerInteractables.GetInteractableObjects());
        }
    }

    private void ShowInteractionText(IInteractables interactables)
    {
        IInteractables interactable = interactables;
        if(playerInteractables.GetCanInteractBool() == true && interactable.IsInteracting() == true)
        {
            dialogueInteractionContainer.SetActive(true);
        }
        else
        {
            dialogueInteractionContainer.SetActive(false);
        }
        canvasInteractionContainer.SetActive(true);
        textMeshProUGUI.text = interactables.GetInteractionText();
    }

    private void HideInteractionText(IInteractables interactables)
    {
        IInteractables interactable = interactables;
        if(playerInteractables.GetCanInteractBool() == false)
        {
            dialogueInteractionContainer.SetActive(false);
        }
        canvasInteractionContainer.SetActive(false);
    }
}
