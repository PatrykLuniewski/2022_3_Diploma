using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu2 : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("LVL2");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("koniec");
    }
}

