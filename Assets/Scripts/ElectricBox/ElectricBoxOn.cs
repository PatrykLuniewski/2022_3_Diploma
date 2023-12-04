using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElectricBoxOn : MonoBehaviour
{

    public Animator electricBoxButton = null;
    public GameObject gameObject = null;
    public Material material = null;
    private Renderer renderer = null;
    public GameObject computer_activation;
    public GameObject objectiveToRemove;
    public GameObject objectiveToAdd;
    public GameObject lights;

    DialogueLib dialogueLib;
    public GameObject startDialogueLine;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement == null)
            {
                playerMovement.showPressToInteract();

            }

        }    


    }
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (Input.GetKey(KeyCode.E))
            {
                renderer = gameObject.GetComponent<Renderer>();
                renderer.material = material;
                electricBoxButton.Play("electric_button_activate", 0, 0.0f);
                objectiveToRemove.SetActive(false);
                objectiveToAdd.SetActive(true);
                lights.SetActive(true);
                computer_activation.SetActive(true);
                dialogueLib = GetComponent<DialogueLib>();
                dialogueLib.StartNewDialoguesLines(startDialogueLine);
                //Destroy(this.gameObject);
            }


        }
    }

}
