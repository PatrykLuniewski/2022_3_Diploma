using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Lvl1_elevator_door_open : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Door2 = null;
    public Animator Door3 = null;

    public void Start()
    {
        StartCoroutine(Delay(3f));
        Debug.Log("assdasdasda");

    }

    IEnumerator Delay(float time)
    {
        Debug.Log("Zaczynamy delay");
        yield return new WaitForSeconds(time);
        Door2.Play("Lvl1_Elevator_Door1_Open", 0, 0.0f);
        Door3.Play("Lvl1_door2", 0, 0.0f);
        Debug.Log("Koniec delay");
    }
}
