using UnityEngine;

public abstract class DialogueConditionTest : MonoBehaviour
{
    public bool conditionMet;

    public virtual void CreateDialogueCondition()
    {

    }

    public DialogueConditionTest InstantiateCondition(Transform NpcParentObject)
    {
        Instantiate(this.gameObject, NpcParentObject);
        return this;
    }
}
