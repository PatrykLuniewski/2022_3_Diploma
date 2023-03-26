using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_floor : MonoBehaviour
{

    public Animator destroy = null;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            destroy.Play("destroy_animation_activate", 0, 0.0f);
        }
    }
}
