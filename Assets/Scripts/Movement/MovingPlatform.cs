using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MovingPlatform : MonoBehaviour
{
    public List<Transform> waypoints;
    public float moveSpeed;
    public int target;

   
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, moveSpeed * Time.deltaTime);
        
    }

    private void FixedUpdate()
    {
        if (transform.position == waypoints[target].position) {
            if (target == waypoints.Count - 1) {
                target = 0;
            } else {
                target += 1;
            }
        }
    }

    

   
}
