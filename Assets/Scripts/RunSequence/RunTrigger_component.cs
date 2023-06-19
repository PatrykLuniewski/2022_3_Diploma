using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTrigger_component : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator fall1 = null;
    public Animator fall2 = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fall1.Play("Fall1", 0, 0.0f);
            fall1.Play("Fall2", 0, 0.0f);
        }
    }
}
