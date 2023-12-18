using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filar4_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator filar4 = null;
    public GameObject gameObject = null;
    public Material material = null;
    private Renderer renderer = null;

    public GameObject door_trigger;
    public GameObject door_trigger2;
    public GameObject gameObject2 = null;

    ChangeObjectiveLib2 changeObjectiveLib2;
    DialogueLib dialogueLib;
    public GameObject addHint1;
    public GameObject dialogueLine1;

    public void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            gameObject2.SetActive(true);
            gameObject2.SetActive(true);
            if(Input.GetKey(KeyCode.E))
            {

                renderer = gameObject.GetComponent<Renderer>();
                renderer.material = material;
                changeObjectiveLib2 = GetComponent<ChangeObjectiveLib2>();
                changeObjectiveLib2.changeObjective(addHint1);
                dialogueLib = GetComponent<DialogueLib>();
                dialogueLib.StartNewDialoguesLines(dialogueLine1);

                filar4.Play("Filar4_animation_activate", 0, 0.0f);
                door_trigger.SetActive(true);
                door_trigger2.SetActive(true);


            }


        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //gameObject2.SetActive(false);
        }
    }
}
