using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractables
{
    void Interact(Transform interactorTransform);
    string GetInteractionText();

    Transform GetInteractionTransform();

    bool IsInteracting();
}
