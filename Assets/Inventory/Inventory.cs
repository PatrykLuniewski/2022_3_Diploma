using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool inventoryEnabled;
    public GameObject inventory;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) { 
        inventoryEnabled = !inventoryEnabled;

            if (inventoryEnabled == true)

            {
                inventory.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                inventory.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

            }


        }   
       
        
    }
}
