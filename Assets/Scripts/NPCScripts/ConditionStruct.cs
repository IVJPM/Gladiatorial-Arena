using UnityEngine;

public struct ConditionStruct
{
    public void ActivateCondition(IConditionObject conditionInformation)
    {
        conditionInformation.RunCondition();
    }
}
