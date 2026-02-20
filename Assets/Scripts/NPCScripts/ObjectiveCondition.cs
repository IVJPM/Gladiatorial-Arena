using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveCondition : DialogueConditionTest
{

    void Start()
    {

        if(objective == null)
        {
            objective = GetComponentInParent<Objective>();
        }

            if (objective != null)
            {
                objective.OnObjectiveFinished += Objective_OnObjectiveFinished;
            }
            else
            {
                print("no objective");
            }

        
        //if(objective == null)
        //StartCoroutine(AssignObjective());
    }

    private void Objective_OnObjectiveFinished(object sender, EventArgs e)
    {
        CreateDialogueCondition();
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
            //conditionStruct.ActivateCondition(condition);
        }

        else if (conditionMet == true)
        {
            return;
        }
    }

    public void AssignObjective(Objective objective)
    {
        if(objective == null)
        {
            this.objective = objective;
        }
    }
}
