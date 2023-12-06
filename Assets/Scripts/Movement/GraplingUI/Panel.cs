using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public NewPlayerMovement player;
    public Image panel;
    private bool readyToHook;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player.readyToHook) {
            panel.color = new Color(255, 255, 255, 0.25f);
            
        } else {
            panel.color = new Color(255, 0, 0, 0.25f);
        }
    }
}
