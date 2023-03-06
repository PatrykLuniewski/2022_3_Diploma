using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1_elevator_door_open1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Door3 = null;

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            Door3.Play("Lvl1_door2", 0, 0.0f);
        }
    }
}
