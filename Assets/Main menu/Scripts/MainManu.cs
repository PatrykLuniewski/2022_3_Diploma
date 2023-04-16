using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Lvl0");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("koniec");
    }
}

