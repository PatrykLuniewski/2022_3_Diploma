using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class KeyPad : MonoBehaviour
{
    [SerializeField] private TMP_Text Ans;
    [SerializeField] private Animator Door;

    private string Answer = "9999" ;

    public void Number(int number)
    {
        Ans.text += number.ToString();
    }
   
    public void Execute()
    {
        if(Ans.text == Answer)
        {
            Ans.text = "Correct";
            Door.SetBool("Open", true);
            StartCoroutine("StopDoor");
        }
        else
        {
            Ans.text = "B��d";
        }
    }
    IEnumerator StopDoor()
    {
        yield return new WaitForSeconds(0.8f);
        Door.SetBool("Open", false);
        Door.enabled = false;
    }
}
