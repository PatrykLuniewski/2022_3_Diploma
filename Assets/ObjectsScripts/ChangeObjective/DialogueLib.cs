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
        for(int i=0;i<dialogueLine.transform.childCount;i++)
        {
            dialogueLine.transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(5f);
            dialogueLine.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public IEnumerator singleDialogueLine(GameObject dialogueLine)
    {
        dialogueLine.SetActive(true);
        yield return new WaitForSeconds(4f);
        dialogueLine.SetActive(false);
    }

    public IEnumerator singleDialogueLineWithTime(GameObject dialogueLine, float time)
    {
        dialogueLine.SetActive(true);
        yield return new WaitForSeconds(time);
        dialogueLine.SetActive(false);
    }
}
