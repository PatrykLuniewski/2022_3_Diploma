using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second : MonoBehaviour
{
    public Animator sufit1 = null;
    public Animator floor1 = null;
    public Animator fire = null;
    public GameObject gameObject = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            sufit1.Play("sufit1", 0, 0.0f);
            floor1.Play("floor_fall1",0,0.0f);
            gameObject.SetActive(true);
            fire.Play("Fire",0,0.0f);
            Destroy(this);

        }
    }

}
