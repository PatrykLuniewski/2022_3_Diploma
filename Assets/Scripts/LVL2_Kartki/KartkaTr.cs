using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KartkaTr : MonoBehaviour
{
    [SerializeField] private Image _Kartka1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _Kartka1.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _Kartka1.enabled = false;
        }
    }
}
        
          

