using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filar3_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator filar3 = null;

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            filar3.Play("Filar3_animation_activate", 0, 0.0f);
            Destroy(this.gameObject);
        }
    }
}
