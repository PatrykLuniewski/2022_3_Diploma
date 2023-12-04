using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLineScript : MonoBehaviour
{
    GameObject dialogue1;
    public void AddNewDialogue(GameObject dialogueLine)
    {
        dialogue1 = dialogueLine;

        if (dialogueLine == null)
        {
            Debug.LogError("dialogueLine jest null");
            return;
        }
        StartCoroutine(DelayedAction(dialogue1));
    }
    public IEnumerator DelayedAction(GameObject dialogueLine)
    {
        dialogueLine.SetActive(true);
        yield return new WaitForSeconds(3f);
        dialogueLine.SetActive(false);
    }
}
