using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour

{

    [SerializeField] private Image _noteImage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
                {
            _noteImage.enabled = true;
        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _noteImage.enabled = false;
        }
    }
}
