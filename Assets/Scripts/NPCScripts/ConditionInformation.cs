using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ConditionInformation : DialogueConditionTest
{
    [SerializeField] ConditionActivation condition;
    [SerializeField] ConditionChoiceTest conditionChoices;
    
    public ButtonControl buttonCondition;
    public bool enableCondition;
    public int conditionInfoID;
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
    }

    public override void SetConditionActive(NPCInteractions npc)
    {
        base.SetConditionActive(npc);
    }
}
