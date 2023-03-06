using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filar1_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator filar1 = null;

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            filar1.Play("Filar1_animation_activate", 0, 0.0f);
        }
    }
}
