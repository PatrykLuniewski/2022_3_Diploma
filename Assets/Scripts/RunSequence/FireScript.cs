using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireScript : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("kolizja");
        if (other.CompareTag("Player"))
        {
            
             Debug.Log("kolizja z graczem");
             SceneManager.LoadScene("DeathLabirynt");

        }
    }
}
