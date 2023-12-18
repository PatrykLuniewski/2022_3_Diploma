using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTriggerScript : MonoBehaviour
{
    public string LevelName;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {

            SceneManager.LoadScene(LevelName);

        }
    }
}
