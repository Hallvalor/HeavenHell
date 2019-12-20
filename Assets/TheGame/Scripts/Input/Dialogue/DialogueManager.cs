using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;

    public bool dialogueActive; 

    void Start()
    {
        
    }

    void Update()
    {
        if(dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            dialogueBox.SetActive(false);
            dialogueActive = false; 
        }
    }

    public void ShowBox(DialogueNPC dialogueNPC)
    { 
       
        if(dialogueNPC.rdmText)
        {
            dialogueActive = true;
            dialogueBox.SetActive(true);
            int rdm = Random.Range(0, dialogueNPC.dialoguesList.Length);
            dialogueText.text = dialogueNPC.dialoguesList[rdm];


        }
        


       

    }
}
