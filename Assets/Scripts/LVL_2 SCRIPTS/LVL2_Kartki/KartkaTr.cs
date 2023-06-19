using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KartkaTr : MonoBehaviour
{
    [SerializeField] private Image _Kartka1;
    [SerializeField] private TMP_Text _text;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _Kartka1.enabled = true;
            _text.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _Kartka1.enabled = false;
            _text.enabled = false;
        }
    }
}
        
          

