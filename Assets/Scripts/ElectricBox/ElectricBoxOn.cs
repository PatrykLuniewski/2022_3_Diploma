using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBoxOn : MonoBehaviour
{

    public Animator electricBoxButton = null;
    public GameObject gameObject = null;
    public Material material = null;
    private Renderer renderer = null;


    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (Input.GetKey(KeyCode.E))
            {
                renderer = gameObject.GetComponent<Renderer>();
                renderer.material = material;
                electricBoxButton.Play("electric_button_activate", 0, 0.0f);
                //Destroy(this.gameObject);
            }


        }
    }

}
