using System;
using System.Collections.Generic;
using UnityEngine;

public class ConditionSpawner : MonoBehaviour
{
    public List<NPCDialogueBranches> dialogueBranches;

    public NPCInteractions npc;
    public List <DialogueConditionTest> condition;
    public List <DialogueConditionTest> conditionClone;
    public int conditionIndex;
    public InteractionTextManagerSO dialogueManager;

    void Awake()
    {
        CreateConditions();
        for (int i = 0; i < dialogueBranches.Count; i++)
        {
            dialogueBranches[i].SetConditionSpawner(this);
        }
    }

    void Update()
    {
        
    }

    public void CreateConditions()
    {
        for (conditionIndex = 0; conditionIndex < condition.Count; conditionIndex++)
        {
            conditionClone[conditionIndex] = dialogueBranches[conditionIndex].condition.InstantiateCondition(npc.transform);
        }
    }
}
