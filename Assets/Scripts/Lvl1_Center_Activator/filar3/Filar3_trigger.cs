using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filar3_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator filar3 = null;
    public GameObject gameObject = null;
    public Material material = null;
    private Renderer renderer = null;
    public GameObject gameObject2 = null;

    public void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            gameObject2.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                renderer = gameObject.GetComponent<Renderer>();
                renderer.material = material;
                filar3.Play("Filar3_animation_activate", 0, 0.0f);
                //Destroy(this.gameObject);
            }

        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject2.SetActive(false);
        }
    }
}
