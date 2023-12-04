using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueLib : MonoBehaviour
{
    // Start is called before the first frame update

    public void SingleDialogueLine(GameObject dialogueLine)
    {
        if (dialogueLine == null)
        {
            Debug.LogError("dialogueLine jest null");
            return;
        }
        StartCoroutine(singleDialogueLine(dialogueLine));
    }
    public void StartNewDialoguesLines(GameObject firstDialogueLine)
    {

        if (firstDialogueLine == null)
        {
            Debug.LogError("dialogueLine jest null");
            return;
        }
        StartCoroutine(multiplyDialoguesLines(firstDialogueLine));
    }
    public IEnumerator multiplyDialoguesLines(GameObject dialogueLine)
    {
        dialogueLine.SetActive(true);
        yield return new WaitForSeconds(3f);
        dialogueLine.SetActive(false);

        if (dialogueLine.transform.childCount > 0)
        {
            GameObject nextDialogueLine = dialogueLine.transform.GetChild(0).gameObject;
            yield return StartCoroutine(multiplyDialoguesLines(nextDialogueLine));
        }
    }
    public IEnumerator singleDialogueLine(GameObject dialogueLine)
    {
        dialogueLine.SetActive(true);
        yield return new WaitForSeconds(3f);
        dialogueLine.SetActive(false);
    }
}
