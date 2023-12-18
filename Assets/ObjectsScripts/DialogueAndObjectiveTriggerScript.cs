using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAndObjectiveTriggerScript : MonoBehaviour
{

    public Boolean manyDialogues;
    ChangeObjectiveLib2 changeObjectiveLib2;
    DialogueLib dialogueLib;
    public GameObject startDialogue;
    public GameObject objective;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (startDialogue!=null)
            {
                dialogueLib = GetComponent<DialogueLib>();
                if (manyDialogues)
                {
                    dialogueLib.StartNewDialoguesLines(startDialogue);
                }
                else
                {
                    dialogueLib.SingleDialogueLine(startDialogue);
                }

            }
            if(objective!=null)
            {
                changeObjectiveLib2 = GetComponent<ChangeObjectiveLib2>();
                changeObjectiveLib2.changeObjective(objective);

            }
        }
    }
}
