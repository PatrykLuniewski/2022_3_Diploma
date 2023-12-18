using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_by_trigger : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject playerObject;
    public GameObject playercomp;
    public GameObject orientacja;
    public GameObject camerapos;
    public GameObject camera;
    public GameObject cameraHolder;
    public Vector3 vector3 = new Vector3(0,1, 0);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            //other.gameObject.transform.position = teleportTarget.position;
            vector3 = new Vector3(0,0,0);
          //  playercomp.transform.position = teleportTarget.position;
            //cameraHolder.transform.position = new Vector3(teleportTarget.position.x, teleportTarget.position.y+0.5f, teleportTarget.position.z);
            playerObject.transform.position = teleportTarget.position;
            // camerapos.transform.position = teleportTarget.position;
            // camera.transform.position = teleportTarget.position;
            // orientacja.transform.position = teleportTarget.position;
            // camera.transform.position= teleportTarget.position;

        }
    }
}
