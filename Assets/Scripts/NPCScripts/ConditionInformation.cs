using UnityEngine;

public class ConditionInformation : DialogueConditionTest
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void CreateDialogueCondition()
    {
        base.CreateDialogueCondition();
        
        if(conditionMet == false)
        {
            conditionMet = true;
        }
        else
        {
            conditionMet = false;
        }
        /*ConditionStruct condition = new ConditionStruct();
        condition.CreateCondition(this);*/
    }
}
