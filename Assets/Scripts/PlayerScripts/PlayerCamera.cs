using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    public float rayLength = 100f; // D³ugoœæ promienia raycast
    private bool isCameraActive = true;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public GameObject showPressToInteractUI;
    void Update()
    {
        if (!isCameraActive)
            return;
        // Obrót kamery
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        //RAYCASTING
        raycastInteraction();


    }

    public void raycastInteraction()
    {
        // Raycast
        RaycastHit hit;
        Vector3 rayDirection = transform.forward; // Kierunek raycasta z kamery

        // Rysowanie raycasta do celów debugowania
        Debug.DrawRay(transform.position, rayDirection * rayLength, Color.green);

        // Wykonywanie raycasta
        if (Physics.Raycast(transform.position, rayDirection, out hit, rayLength))
        {
            // Sprawdzanie, czy trafiony obiekt ma tag "interactable"
            if (Physics.Raycast(transform.position, rayDirection, out hit, rayLength))
            {
            } 
        }
    }



    public void SetCameraActive(bool isActive)
    {
        isCameraActive = isActive;
    }
}
