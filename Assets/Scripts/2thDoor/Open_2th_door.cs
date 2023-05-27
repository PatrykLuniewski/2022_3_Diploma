using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_2th_door : MonoBehaviour
{

     public Animator animator = null;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            animator.Play("door_to_lvl2");
        }
    }
}
