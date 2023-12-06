using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{

    public AudioSource footSteps;
    public NewPlayerMovement player;
    void Start()
    {
        
    }

    void Update()
    {
        
        if (MyInput(KeyCode.W) || MyInput(KeyCode.S) || MyInput(KeyCode.A) || MyInput(KeyCode.D)) {
            if (player.grounded) {
                footSteps.enabled = true;
            }
            
        } else {
            footSteps.enabled = false;
        }
    }

    bool MyInput(KeyCode k) {
        return Input.GetKey(k);
    }
    
}
