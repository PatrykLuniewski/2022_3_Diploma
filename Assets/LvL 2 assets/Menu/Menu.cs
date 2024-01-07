using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    private bool menuEnabled;
    private int escapePressCount = 0; 
    public GameObject menu;
    [SerializeField] private RawImage rawImage;
    [SerializeField] private TMP_Text title;
    public GameObject settingsMenu;
    public GameObject credits;
    public PlayerCamera playerCamera;
    void Start()
    {
        if (menu == null || rawImage == null || title == null || settingsMenu == null || credits == null)
        {        
            enabled = false; 
        }
        HideAll();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escapePressCount++;

            if (escapePressCount % 2 == 1)
            {
                ShowMenu();
            }
            else
            {
                HideAll();
            }
        }

    }
    void ShowMenu()
    {
        menu.SetActive(true);
        rawImage.enabled = true;
        title.enabled = true;        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerCamera.SetCameraActive(false);
    }
    void HideAll()
    {
        menu.SetActive(false);
        rawImage.enabled = false;
        title.enabled = false;
        settingsMenu.SetActive(false);
        credits.SetActive(false);
        Cursor.visible = false;
        playerCamera.SetCameraActive(true);
        Cursor.lockState = CursorLockMode.Locked;

    }

}