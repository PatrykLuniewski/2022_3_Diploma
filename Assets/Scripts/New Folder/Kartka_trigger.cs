using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kartka_trigger : MonoBehaviour
{
    bool isInTrigger=false;
    public GameObject kartka;
    public GameObject dialogueLine;
    DialogueLineScript dialogueLineScript;

    void Update()
    {
        
        if(isInTrigger==true&&Input.GetKeyDown(KeyCode.E))
        {
            dialogueLineScript = GetComponent<DialogueLineScript>();

            if (kartka.active==false)
            {
                kartka.SetActive(true);
            }
            else if (kartka.active == true)
            {
                kartka.SetActive(false);
                dialogueLineScript.AddNewDialogue(dialogueLine);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isInTrigger= true;
    }
    private void OnTriggerExit(Collider other)
    {
        kartka.SetActive(false);
        isInTrigger = false;
    }


}
