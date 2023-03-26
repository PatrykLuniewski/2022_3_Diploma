using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filar1_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator filar1 = null;
    public GameObject gameObject = null;
    public Material material = null;
    private Renderer renderer = null;


    public void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.E))
            {
                renderer = gameObject.GetComponent<Renderer>();
                renderer.material = material;
                filar1.Play("Filar1_animation_activate", 0, 0.0f);
               
                //Destroy(this.gameObject);
            }

        }
    }
}
