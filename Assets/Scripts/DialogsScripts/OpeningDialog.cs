using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDialog : MonoBehaviour
{
    public GameObject dialog1 = null;
    public GameObject dialog2 = null;
    public GameObject dialog3 = null;
    public GameObject dialog4 = null;

    ChangeObjectiveLib changeObjectiveLib;
    public GameObject objectiveToAdd;

    void Start()
    {
        
        StartCoroutine(DelayedAction());
        


    }
    private IEnumerator DelayedAction()
    {
        dialog1.SetActive(true);
        yield return new WaitForSeconds(2f);
        dialog1.SetActive(false);
        dialog2.SetActive(true);
        yield return new WaitForSeconds(3f);
        dialog2.SetActive(false);
        dialog3.SetActive(true);
        yield return new WaitForSeconds(3f);
        dialog3.SetActive(false);
        dialog4.SetActive(true);
        yield return new WaitForSeconds(3f);
        dialog4.SetActive(false);
        changeObjectiveLib = GetComponent<ChangeObjectiveLib>();
        changeObjectiveLib.addObjective(objectiveToAdd);

    }


}
