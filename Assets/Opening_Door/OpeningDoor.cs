using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Door = null;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Door.Play("DoorOpen", 0, 0.0f);
        }
    }
}
