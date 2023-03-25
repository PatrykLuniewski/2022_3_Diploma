using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filar4_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator filar4 = null;

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            filar4.Play("Filar4_animation_activate", 0, 0.0f);
            Destroy(this.gameObject);

        }
    }
}
