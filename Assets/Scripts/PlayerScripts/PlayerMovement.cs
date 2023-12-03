using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]

    public float walkSpeed;
    public float sprintSpeed; 
    public float groundDrag; //efekt �lizgania si� po pod�odze im wi�cej tym mniej si� �lizgasz


    [Header("Jumping")]
    public float jumpForce; //si�a skoku ? 
    public float jumpCooldown;
    public float airMultiplier; //szybko�� poruszania si� w powietrzu
    bool readyToJump;

    [Header("crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;
  

    //private
    private float moveSpeed; //chodzenie




    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;


    [Header("Ground Check")]
    public float playerHeight;//potrzebne do okre�lenia czy dotykamy pod�ogi
    public LayerMask whatIsGround;
    bool grounded;//czy dotykamy pod�ogi

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public Transform orientation;

    [Header("Slope Handling")]
    private bool exitingSlope;
    public float maxSlopeAngle;
    private RaycastHit slopeHit;

    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;


    

    Rigidbody rb;

    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting,
        air,
        crouching,
        freeze
    }

    public bool freeze;
    public bool activeGrapple;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;


        readyToJump = true;


        startYScale = transform.localScale.y;


    }

    private void Update()
    {

        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        MyInput();
        SpeedControl();
        StateHandler();

        // handle drag

        if (grounded && !activeGrapple)
        {
            rb.drag = groundDrag;

        }
        else
        {
            rb.drag = 0;
        }

        Debug.Log(grounded);




    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            
            readyToJump = false;
            

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        if(Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down*5f, ForceMode.Impulse);
        }
        if(Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale,transform.localScale.z);
        }
    }

    private void StateHandler()
    {
        if(freeze)
        {
            state = MovementState.freeze;
            moveSpeed= 0;
            rb.velocity = Vector3.zero;
        }
        else
        {
            state = MovementState.walking;
        }


        if(Input.GetKeyDown(crouchKey))
        {
            moveSpeed = crouchSpeed;
            state = MovementState.crouching;
        }

        //sprint
        if(grounded&& Input.GetKey(sprintKey) && state != MovementState.crouching) 
        {
            moveSpeed = sprintSpeed;
            state = MovementState.sprinting;
            
        }
        //walking
        else if(grounded && !Input.GetKey(sprintKey) && !Input.GetKey(crouchKey) /*&& state != MovementState.freeze*/)
        {
            moveSpeed = walkSpeed;
            state = MovementState.walking;
            
        }
        //air movement
        else if(!grounded)
        {
            state = MovementState.air;
        }    
    }

    private void MovePlayer()
    {
        if (activeGrapple) return;
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //on slope
        if(OnSlope()==true && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection()*moveSpeed*20f, ForceMode.Force);

            if(rb.velocity.y>0)
            {
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
            }
        }

        // on ground
        if (grounded==true)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (grounded==false)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        //grawitacja wy��czona podczasz przebywania na nachylonej powierzchni
        rb.useGravity = !OnSlope();
    }

    private void SpeedControl()
    {
        if(activeGrapple==true)
        {
            return;
        }
        if(OnSlope()==true)
        {
            if(rb.velocity.magnitude > moveSpeed)
            {
                rb.velocity = rb.velocity.normalized * moveSpeed;
            }
        }

        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            // limit velocity if needed
            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }

    }

    private void Jump()
    {
        exitingSlope = true;
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
        exitingSlope= false;
    }
    private Vector3 velocityToSet;
    public void JumpToPosition(Vector3 targerPosition, float trajectoryHeight)
    {
        activeGrapple = true;
        velocityToSet = CalculateJumpVelocity(transform.position, targerPosition, trajectoryHeight);
        Invoke(nameof(SetVelocity), 0.1f);

    }

    
    private void SetVelocity()
    {
        rb.velocity = velocityToSet;
    }
    private bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight *0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle !=0;
        }
        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {

        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }


    public Vector3 CalculateJumpVelocity(Vector3 startPoint, Vector3 endPoint, float trajectoryHeight)
    {
        float gravity = Physics.gravity.y;
        float displacementyY = endPoint.y - startPoint.y;
        Vector3 displacementXZ = new Vector3(endPoint.x - startPoint.x, 0f, endPoint.z - startPoint.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * trajectoryHeight);
        Vector3 velocityXZ = displacementXZ /(Mathf.Sqrt(-2*trajectoryHeight/gravity) + Mathf.Sqrt(2*(displacementyY-trajectoryHeight) / gravity));
        return velocityXZ + velocityY;
    }

    public GameObject PressToInteractUI;
    public void showPressToInteract()
    {
        PressToInteractUI.SetActive(true);
    }
    public TextMeshPro objectiveTextUI;
    public GameObject objectiveUI;
    public void showObjective(string textToSet)
    {
        objectiveUI.SetActive(true);
        objectiveTextUI.SetText(textToSet);
    }
    public void hideObjective(string textToSet)
    {
        objectiveUI.SetActive(true);
        objectiveTextUI.SetText(textToSet);
    }
    public float rayLength = 5f; // Długość promienia raycast

}