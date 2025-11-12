using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ConditionInformation : DialogueConditionTest
{
    [SerializeField] ConditionActivation condition;
    [SerializeField] ConditionChoiceTest conditionChoices;
    
    public Button buttonCondition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        conditionMet = false;
        //conditionChoices.OnChoiceDecided += ConditionChoices_OnChoiceDecided;
    }

    //private void ConditionChoices_OnChoiceDecided(object sender, EventArgs e)
    //{
    //    print("n");
    //    CreateDialogueCondition();
    //}

    // Update is called once per frame
    void Update()
    {
        
    }



    public override void CreateDialogueCondition()
    {
        base.CreateDialogueCondition();
        
        if (conditionMet == false)
        {   
            ConditionStruct conditionStruct = new ConditionStruct();
            conditionMet = true;
            conditionStruct.ActivateCondition(condition);
        }
        else
        {
            conditionMet = false;
        }
        /*ConditionStruct condition = new ConditionStruct();
        condition.CreateCondition(this);*/
    }
}
