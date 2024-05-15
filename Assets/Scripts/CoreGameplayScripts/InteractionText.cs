using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[System.Serializable]
public class InteractionText
{
     public TextMeshProUGUI textMeshProDialogue;
     public string npcName;
     public PlayerInputManager playerInputManager;


    [Header("Dialogue Options")]
     public int maxDialogueChoices;
     public int increaseMaxDialogueChoices;
     public List<string> dialogueChoices = new List<string>();
     public List<int> setsOfDialogue = new List<int>();
     public int currentSetOfDialogue;
     public int currentDialogueChoice;
    //[SerializeField]string[,] dialogueOptions;

    public string CharacterDialogue()
    {
        for (int i = 0; i < setsOfDialogue.Count; i++)
        {
            dialogueChoices.Capacity = maxDialogueChoices;
            if (i == setsOfDialogue[0])
            {
                if (currentDialogueChoice < dialogueChoices.Capacity)
                {
                    //for (int j = currentDialogueChoice; j < maxDialogueChoices; j++)
                    //{
                    textMeshProDialogue.text = dialogueChoices[currentDialogueChoice];
                    //}
                }
                else
                {
                    // Try making a new script and using [System.Serializable]!!!!
                    currentDialogueChoice = -1;
                }
            }
        }
        currentDialogueChoice++;
        return textMeshProDialogue.text;
    }
}
