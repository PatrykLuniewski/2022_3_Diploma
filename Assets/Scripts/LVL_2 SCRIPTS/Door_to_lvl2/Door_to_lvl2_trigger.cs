using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_to_lvl2_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator door_to_lvl2 = null;

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            door_to_lvl2.Play("opening_fragments_animation", 0, 0.0f);
            Destroy(this.gameObject);
        }
    }
}
