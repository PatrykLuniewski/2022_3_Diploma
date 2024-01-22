using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    
    public TMP_Text textElement;
    public TMP_Text textElement2;

    public GameObject panel;
    void Start()
    {
        textElement.gameObject.SetActive(false);
        textElement2.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) {
            textElement.gameObject.SetActive(true);
            textElement2.gameObject.SetActive(true);
            panel.gameObject.SetActive(true);
        } else {
            textElement.gameObject.SetActive(false);
            textElement2.gameObject.SetActive(false);
            panel.gameObject.SetActive(false);
        }
    }
}
