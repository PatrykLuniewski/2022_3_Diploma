using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kartka_trigger : MonoBehaviour
{
    bool isInTrigger=false;
    public GameObject kartka;

    void Update()
    {
        if(isInTrigger==true&&Input.GetKeyDown(KeyCode.E))
        {
            if(kartka.active==false)
            {
                kartka.SetActive(true);
            }
            else if (kartka.active == true)
            {
                kartka.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isInTrigger= true;
    }
    private void OnTriggerExit(Collider other)
    {
        kartka.SetActive(false);
        isInTrigger = false;
    }


}
