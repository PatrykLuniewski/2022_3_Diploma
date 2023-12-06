using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{

    public AudioSource footSteps;
    public AudioSource sprint;
    public NewPlayerMovement player;
    void Start()
    {
        
    }

    void Update()
    {
        
        if (MyInput(KeyCode.W) || MyInput(KeyCode.S) || MyInput(KeyCode.A) || MyInput(KeyCode.D)) {
            if (player.grounded) {
                if (MyInput(KeyCode.LeftShift)) {
                    sprint.enabled = true;
                } else {
                    footSteps.enabled = true;
                    sprint.enabled = false;
                }
                    
            } 
            
        } else {
            footSteps.enabled = false;
            sprint.enabled = false;
        }

        if (MyInput(KeyCode.LeftShift) && player.grounded) {
            sprint.enabled = true;
        } else {
            sprint.enabled = false;
        }
    }

    bool MyInput(KeyCode k) {
        return Input.GetKey(k);
    }
    
}
