using UnityEngine;

public struct ConditionStruct
{
    public void CreateCondition(DialogueConditionTest conditionInformation, KeyCode characterReply)
    {
        if (Input.GetKeyDown(characterReply))
        {
            Debug.Log(characterReply);
            conditionInformation.conditionMet = true;
        }
    }
}
