using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class OpenDoor : MonoBehaviour
{

    private Animator anim;
    private bool IsAtDoor = false;
    public GameObject objectiveToRemove;
    public GameObject objectiveToAdd;
    public PlayerCamera playerCamera;

    [SerializeField] private TextMeshProUGUI CodeText;
    string codeTextValue = "";
    public string SafeCode;
    public GameObject CodePanel;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CodeText.text = codeTextValue;

        if (codeTextValue == SafeCode)
        {
            anim.SetTrigger("OpenDoor");
            CodePanel.SetActive(false);

        }
        if (codeTextValue.Length >= 4)
        {
            codeTextValue = "";
        }
        if (Input.GetKey(KeyCode.E) && IsAtDoor == true)
        {
            CodePanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            playerCamera.SetCameraActive(false);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsAtDoor = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        IsAtDoor = false;
        CodePanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        objectiveToRemove.SetActive(false);
        objectiveToAdd.SetActive(true);
        playerCamera.SetCameraActive(true);
    }
    public void AddDigit(string dignit)
    {
        codeTextValue += dignit;
    }


}
