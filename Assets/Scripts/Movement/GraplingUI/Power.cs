using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    public NewPlayerMovement player;
    public Image img;
    public float interval = 1f;
    public float startDelay = 0.5f;
    public bool currentState = true;
    public bool defaultState = true;
    
    bool isBlinking = false;
    
        void Start()
    {
        img.enabled = defaultState;

        
        
    }

    void Update()
    {
        if (!player.readyToHook) {
            StartBlinking();
        } else {
            img.enabled = true;
        }
    }

    public void StartBlinking() {
        if (isBlinking)
            return;

        if (img != null) {
            isBlinking = true;
            InvokeRepeating("ToggleState", startDelay, interval);
        }
    }

    public void ToggleState() {
        img.enabled = !img.enabled;
    }

    
}
