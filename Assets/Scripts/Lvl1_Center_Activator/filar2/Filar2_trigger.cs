using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filar2_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator filar2 = null;

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            filar2.Play("Filar2_animation_activate", 0, 0.0f);
            Destroy(this.gameObject);
        }
    }
}
