using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTheDoor : MonoBehaviour
{

    public Animator door1 = null;
    public Animator door2 = null;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.E))
            {
                door1.Play("close1", 0, 0.0f);
                door2.Play("close2", 0, 0.0f);
            }
        }
    }
}
