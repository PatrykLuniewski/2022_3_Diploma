using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1_elevator_door_open : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Door2 = null;

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            Door2.Play("Lvl1_Elevator_Door1_Open", 0, 0.0f);
        }
    }
}
