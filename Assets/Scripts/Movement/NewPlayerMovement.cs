using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class NewPlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform debugHitPointTransform;

    [Header("Movement")]
    public float moveSpeed;

    public float sprint;


    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float hookCooldown;
    bool readyToJump = true;


    private Quaternion posss;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;



    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private Camera playerCamera;
    private State state;
    private Vector3 hookShotPos;
    public bool readyToHook = true;


    private enum State {
        Normal,
        HookshotFlyingPlayer
    }

    private void Awake() {
        playerCamera = transform.Find("Camera").GetComponent<Camera>();
        state = State.Normal;
    }

    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update() {


        
        


        switch (state) {
            default:
            case State.Normal:
                grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

                MyInput();
                SpeedControl();
                HandleHookshotStart();
                rb.useGravity = true;

                 if(grounded) {
                     rb.drag = groundDrag;
                 } else {
                     rb.drag = 0;
                 }
                break;
            case State.HookshotFlyingPlayer:
                //playerCamera.transform.rotation = posss;
                HandleHookshotMovement();
                rb.useGravity = false;
                break;
        }

        
    }

    private void FixedUpdate() {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(Input.GetKey(KeyCode.LeftShift)) {
            MovePlayer(moveDirection, sprint);
        } else {
            MovePlayer(moveDirection, moveSpeed);
        }

        

        
    }

    private void MyInput() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && readyToJump && grounded) {
            readyToJump = false;


            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

       
        
    }

    private void MovePlayer(Vector3 moveDirection, float moveSpeed){
        if (grounded) {
            rb.AddForce(moveDirection.normalized * moveSpeed *8f, ForceMode.Force);
        }
            
    }

   

    private void SpeedControl() {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed) {
            Vector3 limitVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }

    private void Jump() {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump() {
        readyToJump = true;
    }

    private void ResetHook() {
        readyToHook = true;
    }

    private void HandleHookshotStart() {

        if (Input.GetKey(KeyCode.Mouse1)  && readyToHook && !grounded) {
            // posss = playerCamera.transform.rotation;

            

            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit raycastHit)) {
                debugHitPointTransform.position = raycastHit.point;
                hookShotPos = raycastHit.point;
                state = State.HookshotFlyingPlayer;
            }
            readyToHook = false;

            Invoke(nameof(ResetHook), hookCooldown * Time.deltaTime);
        } 
    }

    private void HandleHookshotMovement() {
        Vector3 hookShotDir = (hookShotPos - playerCamera.transform.position).normalized;

        
        


        float min = 1f;
        float max = 25f;

        float hookShotSpeed = Mathf.Clamp(Vector3.Distance(playerCamera.transform.position, hookShotPos), min, max);

        
        rb.AddForce(hookShotDir.normalized * hookShotSpeed * 1.1f, ForceMode.Force);

        float reachedPos = 2f;

        Debug.Log(Vector3.Distance(playerCamera.transform.position , hookShotPos));


        if (!Input.GetKey(KeyCode.Mouse1)) {
            state = State.Normal;
        }
        // if ( Vector3.Distance(playerCamera.transform.position, hookShotPos) < reachedPos || !(Input.GetKey(KeyCode.E))) {
        //     state = State.Normal;
        // }
    }
}
