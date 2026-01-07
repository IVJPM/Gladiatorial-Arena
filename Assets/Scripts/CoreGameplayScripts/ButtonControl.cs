using System;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    public ConditionInformation condition;
    public ConditionChoiceTest conditionChoiceTest;
    [SerializeField] int buttonID;    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        conditionChoiceTest = GetComponentInParent<ConditionChoiceTest>();
        for(int i = 0; i < conditionChoiceTest.buttonChoices.Count; i++)
        {
            if (conditionChoiceTest.buttonChoices[i].conditionInfoID == buttonID)
            {
                condition = conditionChoiceTest.buttonChoices[i];
            }
        }
    }

    public void ProcCondition()
    {
        if(condition != null)
        {
            condition.CreateDialogueCondition();
        }
    }
}
