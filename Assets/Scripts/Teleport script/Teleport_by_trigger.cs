using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_by_trigger : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject player;
    public GameObject camera;
    public Vector3 vector3 = new Vector3(0,1, 0);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            other.gameObject.transform.position = teleportTarget.position;
            player.transform.position = teleportTarget.position;
            vector3 = new Vector3(teleportTarget.position.x, teleportTarget.position.y+0.5f, teleportTarget.position.z);
            camera.transform.position = vector3;
        }
    }
}
