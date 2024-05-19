using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestInformationSO", menuName = "QuestScriptableObject/QuestInformation", order = 1)]
public class QuestInformationSO : ScriptableObject
{
    [field: SerializeField] public string questID {  get; set; }

    [Header("General Quest Information")]
    public string questName;

    [Header("Quest Requirements")]
    public int levelRequirement;
    public QuestInformationSO[] questPrerequisities;

    [Header("Quest Steps")]
    public GameObject[] prerequisiteSteps;

    [Header("Quest Rewards")]
    public int experienceLevelReward;
    public GameObject gameObjectReward;
    public string newQuestInformation;



    private void OnValidate()
    {   //Makes sure the questID matches the name of the ScriptableObject
        #if UNITY_Editor
        questID = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
}
