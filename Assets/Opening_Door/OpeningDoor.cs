using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Door = null;

    public void OnTriggerEnter(Collider other)
    {
        Console.WriteLine("Hello World!");
        if (other.CompareTag("Player"))
        {
            Console.WriteLine("Hello World!");
            Door.Play("DoorOpen", 0, 0.0f);
        }
    }
}
