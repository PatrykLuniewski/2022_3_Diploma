using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("LVl0");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("koniec");
    }
}

