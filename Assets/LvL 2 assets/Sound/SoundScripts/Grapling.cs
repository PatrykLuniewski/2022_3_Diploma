using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapling : MonoBehaviour
{
    public NewPlayerMovement player;
    public AudioSource graplingSound;

    void Update()
    {
        if (!player.grounded && Input.GetKey(KeyCode.Mouse1)) {
            graplingSound.enabled = true;
        } else {
            graplingSound.enabled = false;
        }
    }
}
