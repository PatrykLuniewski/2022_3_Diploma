using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_floor : MonoBehaviour
{

    public Animator destroy1 = null;
    public Animator destroy2 = null;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            destroy1.Play("destroy_floor1", 0, 0.0f);
            destroy2.Play("destroy_floor2", 0, 0.0f);
        }
    }
}
