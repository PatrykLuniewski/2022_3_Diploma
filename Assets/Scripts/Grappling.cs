using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    [Header("variables")]
    private PlayerMovement pm;
    public Transform cam;
    public Transform gunTip;
    public LayerMask whatIsGrappleable;
    public LineRenderer lineRenderer;

    [Header("Grapping")]
    public float maxGrappleDistance;
    public float grappleDelayTime;
    public float overshootYAxis;
    private Vector3 grapplePoint;


    [Header("cooldown")]
    public float grapplingCd;
    private float grapplingCdTimer;


    [Header("Input")]
    public KeyCode grappleKey = KeyCode.Mouse1;

    private bool grappling;


    void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }

    private void StartGrapple()
    {

            if (grapplingCdTimer > 0) return;

            grappling = true;

            pm.freeze = true;

            RaycastHit hit;
            if (Physics.Raycast(cam.position, cam.forward, out hit, maxGrappleDistance, whatIsGrappleable))
            {
                grapplePoint = hit.point;

                Invoke(nameof(ExecuteGrapple), grappleDelayTime);
            }
            else
            {
                grapplePoint = cam.position + cam.forward * maxGrappleDistance;

                Invoke(nameof(ExecuteGrapple), grappleDelayTime);
            }
            lineRenderer.enabled= true;
            lineRenderer.SetPosition(1, grapplePoint);

    }

    private void ExecuteGrapple()
    {
        pm.freeze = false;

        Vector3 lowestPoint = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);

        float grapplePointRelativeYPos = grapplePoint.y - lowestPoint.y;
        float highestPointOnArc = grapplePointRelativeYPos + overshootYAxis;

        if (grapplePointRelativeYPos < 0) highestPointOnArc = overshootYAxis;

        pm.JumpToPosition(grapplePoint, highestPointOnArc);

        Invoke(nameof(stopGrapple), 1f);



    }

    private void stopGrapple()
    {
        pm.freeze = false;
        grappling= false;
        grapplingCdTimer = grapplingCd;

        lineRenderer.enabled= false;
    }   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(grappleKey)) StartGrapple();

        if(grapplingCdTimer>0)
        {
            grapplingCdTimer -=Time.deltaTime; 
        }
   
    }
    private void LateUpdate()
    {
        if(grappling)
        {
            lineRenderer.SetPosition(0, gunTip.position);
        }
    }
}
