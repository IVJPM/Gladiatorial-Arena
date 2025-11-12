using System;
using UnityEngine;
using UnityEngine.UI;

public class ConditionChoiceTest : DialogueConditionTest
{
    public event EventHandler OnChoiceDecided;

    [SerializeField] ConditionActivation condition;

    public ConditionInformation yesCondition;
    [SerializeField] ConditionInformation noCondition;
    //public Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {// Maybe use ConditionStruct to modularize different condition outcomes (new dialogue, present choices, enable quests, etc.)
        if (this.isActiveAndEnabled)
            conditionMet = true;
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


    public void YesButtonClick()
    {
        //OnChoiceDecided?.Invoke(this, EventArgs.Empty);
        yesCondition.CreateDialogueCondition();
    }

    public void NoButtonClick()
    {
        //OnChoiceDecided?.Invoke(this, EventArgs.Empty);
        noCondition.CreateDialogueCondition();
    }
}
