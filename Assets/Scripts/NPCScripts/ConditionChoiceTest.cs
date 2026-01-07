using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionChoiceTest : DialogueConditionTest
{
    [SerializeField] ConditionActivation condition;
    [SerializeField] GameObject npcParent;
    [SerializeField] NPCInteractions npcInteractions;
    public List<ConditionInformation> buttonChoices;

    public ConditionInformation yesCondition;
    [SerializeField] ConditionInformation noCondition;
    GameObject yesAnswer;
    GameObject noAnswer;

    public int choiceIndex;
    public List<GameObject> answers;
    public List<GameObject> answerChoices;
    //public Button button; Maybe create separate "Button Manager" to create lists of buttons to assign different choices

    void Start()
    {
        npcParent = GetComponentInParent<NPCInteractions>().gameObject;
        npcInteractions = GetComponentInParent<NPCInteractions>();
        npcInteractions.OnDialogueSet += NpcInteractions_OnDialogueSet;

        answerChoices.Add(yesCondition.gameObject);
        answerChoices.Add(noCondition.gameObject);

        for (choiceIndex = 0; choiceIndex < npcParent.GetComponentsInChildren<ConditionInformation>().Length; choiceIndex++)
        {
            buttonChoices.Add(npcParent.GetComponentsInChildren<ConditionInformation>()[choiceIndex]);
        }

        gameObject.SetActive(false);
    }


    private void NpcInteractions_OnDialogueSet(object sender, EventArgs e)
    {
        gameObject.SetActive(false);
    }

    void Update()
    {// Maybe use ConditionStruct to modularize different condition outcomes (new dialogue, present choices, enable quests, etc.)
        if (gameObject.activeInHierarchy)
        {
            conditionMet = true;
        }
        else if(!gameObject.activeInHierarchy)
        {
            print("d");
            conditionMet = false;
        }
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

    public void YesButtonClick()
    {
        yesAnswer.GetComponent<ConditionInformation>().CreateDialogueCondition();
    }

    public void NoButtonClick()
    {
        noAnswer.GetComponent<ConditionInformation>().CreateDialogueCondition();
    }
}
