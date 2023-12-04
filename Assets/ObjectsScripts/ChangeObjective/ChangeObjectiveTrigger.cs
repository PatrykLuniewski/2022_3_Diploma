using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeObjectiveTrigger : MonoBehaviour
{
    public GameObject objectiveToSet;
    public GameObject objectiveToRemove;
    public bool anyDialogueBool=false;
    public GameObject dialogueToAdd;
    // Start is called before the first frame update
    private bool active=true;
    private DialogueLineScript dialogueLineScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&& active==true)
        {
            active = false;
            changeObjective(objectiveToRemove, objectiveToSet);
            if(anyDialogueBool)
            {
                dialogueLineScript = GetComponent<DialogueLineScript>();
                dialogueLineScript.AddNewDialogue(dialogueToAdd);
            }
            //Destroy(this);
            

        }
    }   

    public void changeObjective(GameObject objectiveToRemove,GameObject objectiveToSet)
    {
        objectiveToRemove.SetActive(false) ;
        objectiveToSet.SetActive(true) ;
    }
}
