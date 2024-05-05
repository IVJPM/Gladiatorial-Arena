using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractionTextManagerSO", menuName = "InteractionTextSO/InteractionDialogue")]

public class InteractionTextManagerSO : ScriptableObject
{
    [Header("Dialogue Options")]
    [SerializeField] string npcName;
    [TextArea(3, 10)]
    public List<string> npcDialogue;

    /*[SerializeField] TextMeshProUGUI textMeshProDialogue;
    [SerializeField] string npcName;
    [SerializeField] PlayerInputManager playerInputManager;


    [Header("Dialogue Options")]
    [SerializeField] int maxDialogueChoices;
    [SerializeField] int increaseMaxDialogueChoices;
    [SerializeField] List<string> dialogueChoices = new List<string>();
    [SerializeField] List<int> setsOfDialogue = new List<int>();
    private int currentSetOfDialogue;
    [SerializeField] int currentDialogueChoice;
    //[SerializeField]string[,] dialogueOptions;*/
   
   
    public void CharacterDialogue()
    {
       /* if(Vector3.Distance(player.position, npc.transform.position) < 1)
        {
            Debug.Log("not null");
            for (int i = 0; i < setsOfDialogue.Count; i++)
            {
                dialogueChoices.Capacity = maxDialogueChoices;
                if (i == setsOfDialogue[0])
                {
                    if (currentDialogueChoice < dialogueChoices.Count)
                    {
                        for (int j = currentDialogueChoice; j < maxDialogueChoices; j++)
                        {
                            textMeshProDialogue.text = dialogueChoices[j];
                            Debug.Log(textMeshProDialogue.text);
                            break;
                        }
                    }
                    else
                    {
                        // Try making a new script and using [System.Serializable]!!!!
                        currentDialogueChoice = -1;
                    }
                }
            }
        }
        else if(Vector3.Distance(player.position, npc.transform.position) > 1)
        {
            currentDialogueChoice = -1;
            Debug.Log("null");
        }
        currentDialogueChoiceNPC*/

        //return npcDialogue[0].ToString();
    }
}
