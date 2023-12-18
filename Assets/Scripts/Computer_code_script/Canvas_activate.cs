using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;

public class Canvas_activate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    private bool is_in_trigger;
    private bool is_active=false;
    public GameObject player;
    public TextMeshProUGUI codeText;
    private String codeTextValue;
    public String safeCode = "6969";
    public GameObject pilar1;
    public GameObject pilar2;
    public GameObject pilar3;
    public GameObject pilar4;
    public GameObject PressTointeract;
    public PlayerCamera playerCamera;

  
    public GameObject addHint;

    public GameObject addHint2;
    ChangeObjectiveLib changeObjectiveLib = new ChangeObjectiveLib();
    ChangeObjectiveLib2 changeObjectiveLib2;


    public GameObject dialogueLine;
    public GameObject dialogueLine2;
    DialogueLineScript dialogueLineScript;
    DialogueLib dialogueLib;
    public GameObject startDialogueLine;
    private bool firstDialogue=true;
    void Start()
    {

    }
    private void Update()
    {
        codeText.text = codeTextValue;

        if (is_in_trigger==true&&Input.GetKeyDown(KeyCode.E))
        {


            

            if (is_active==false) 
            {
                is_active=true;
                panel.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                playerCamera.SetCameraActive(false);


            }
            else 
            {
                is_active=false;
                panel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                playerCamera.SetCameraActive(true);
            }
            if (firstDialogue == true)
            {
                changeObjectiveLib2 = GetComponent<ChangeObjectiveLib2>();
                changeObjectiveLib2.changeObjective(addHint);
                dialogueLineScript = GetComponent<DialogueLineScript>();
                dialogueLineScript.AddNewDialogue(dialogueLine);
                firstDialogue= false;
            }





        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            is_in_trigger = true;
            PressTointeract.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            is_in_trigger = false;
            panel.SetActive(false);
            PressTointeract.SetActive(false);
        }
    }
    public void AddDigit(String digit)
    {
        if(codeText.text==safeCode)
        {

        }
        else if(codeText.text=="B£¥D")
        {
            codeTextValue = "";
            codeText.text = "";
            codeTextValue += digit;
        }
        else
        {
            codeTextValue += digit;
        }
        
    }
    public void execute()
    {
        if(safeCode==codeTextValue)
        {
            codeTextValue = "ACTIVATE";
            codeText.text = "ACTIVATE";
            pilar1.SetActive(true);
            pilar2.SetActive(true);
            pilar3.SetActive(true);
            pilar4.SetActive(true);
            changeObjectiveLib2 = GetComponent<ChangeObjectiveLib2>();
            changeObjectiveLib2.changeObjective(addHint2);
            dialogueLib = GetComponent<DialogueLib>();
            dialogueLib.SingleDialogueLine(dialogueLine2);
            Debug.LogError("dialogueLine jest null");

        }
        else 
        {

            codeText.text = "B£¥D";
            codeTextValue = "";
        }
    }


}
