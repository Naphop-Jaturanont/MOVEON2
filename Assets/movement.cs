using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum viewpoint
{
    FPS,
    TPS,
    SC
}

public class movement : MonoBehaviour
{
    private CharacterController controller;
    [HideInInspector] public Animator animator;
    private Vector3 playerVelocity;
    [SerializeField] private bool groundedPlayer;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    //Run
    [SerializeField] private float runSpeed = 5f;
    //[SerializeField] private bool isRun;

    //checkground
    [HideInInspector] public Rigidbody rb;
    public Transform checkground;
    [SerializeField] private LayerMask ground;
    [SerializeField] public LayerMask climbLedge;

    //Raycast check
    [SerializeField] public Transform head;
    [SerializeField] public Transform chest;

    Vector3 move;
    Vector3 direction;
    string state;
    public bool climbOn;
    float turnSmoothVelocity;
    [SerializeField] private float rotationSpeed = 0.1f;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform cameraFPS;
    private endbehav testbe;
    private climb Climb;

    public viewpoint Viewpoint;
    private Quaternion lookLeft;
    private Quaternion lookRight;

    //
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        rb = gameObject.AddComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
        Climb = gameObject.GetComponent<climb>();
        lookRight = transform.rotation;
        lookLeft = lookRight * Quaternion.Euler(0, 180, 0);
    }

    void Update()
    {
        groundedPlayer = IsGround();
        if (climbOn == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("cimbup");
                animator.SetBool("Climb", false);
                //testbe = animator.GetBehaviour<endbehav>();
                //testbe.OnStateExit(animator, rb);
            }

        }
        else if (climbOn == false)
        {

            Climb.checkClimb();
            //Climb.enabled = true;
            //rb.isKinematic = false;
            //rb.useGravity = true;
        }

        //groundedPlayer = IsGround();
        if (IsGround() && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        switch (Viewpoint)
        {
            case viewpoint.FPS:
                FPSMove();
                break;
            case viewpoint.TPS:
                TPSMove();
                break;
            case viewpoint.SC:
                SCMove();
                break;
        }
        


        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && IsGround() && climbOn == false)
        {
            Debug.Log("jump");
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            animator.CrossFadeInFixedTime("Jump", 0.1f);

        }
        if (climbOn == false)
        {
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }


    }

    public void SCMove()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.rotation = lookRight;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.rotation = lookLeft;
        }
        //direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        //direction = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * direction;
        //direction.Normalize();
        if (climbOn == false)
        {
            if (move != Vector3.zero)
            {
                //Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);

                //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360 * Time.deltaTime);

                state = IsRun() ? "Run" : "Walk";
                stateCharacter(state);


            }
            else if (move == Vector3.zero)
            {
                stateCharacter("Idle");
            }
        }
    }

    public void TPSMove()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        direction = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * direction;
        direction.Normalize();
        if (climbOn == false)
        {
            if (move != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360 * Time.deltaTime);

                state = IsRun() ? "Run" : "Walk";
                stateCharacter(state);


            }
            else if (move == Vector3.zero)
            {
                stateCharacter("Idle");
            }
        }
    }

    public void FPSMove()
    {
        move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        transform.rotation = Quaternion.Euler(0, cameraFPS.rotation.eulerAngles.y, 0);
        transform.Translate(move * Time.deltaTime * playerSpeed);
        if (climbOn == false)
        {
            if (move != Vector3.zero)
            {
                //Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);

                //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360 * Time.deltaTime);

                state = IsRun() ? "Run" : "Walk";
                stateCharacter(state);


            }
            else if (move == Vector3.zero)
            {
                stateCharacter("Idle");
            }
        }
    }
    public void stateCharacter(string state)
    {
        switch (Viewpoint)
        {
            case viewpoint.FPS:
                switch (state)
                {
                    case "Idle":
                        animator.SetFloat("speed", 0f);
                        break;
                    case "Walk":
                        animator.SetFloat("speed", 2.0f);
                        controller.Move(move * Time.deltaTime * playerSpeed);
                        break;
                    case "Run":
                        controller.Move(move * Time.deltaTime * runSpeed);
                        animator.SetFloat("speed", 4.3f);
                        break;
                }
                break;
            case viewpoint.TPS:
                switch (state)
                {
                    case "Idle":
                        animator.SetFloat("speed", 0f);
                        break;
                    case "Walk":
                        animator.SetFloat("speed", 2.0f);
                        controller.Move(direction * Time.deltaTime * playerSpeed);
                        break;
                    case "Run":
                        controller.Move(direction * Time.deltaTime * runSpeed);
                        animator.SetFloat("speed", 4.3f);
                        break;
                }
                break;
            case viewpoint.SC:
                switch (state)
                {
                    case "Idle":
                        animator.SetFloat("speed", 0f);
                        break;
                    case "Walk":
                        animator.SetFloat("speed", 2.0f);
                        controller.Move(move * Time.deltaTime * playerSpeed);
                        break;
                    case "Run":
                        controller.Move(move * Time.deltaTime * runSpeed);
                        animator.SetFloat("speed", 4.3f);
                        break;
                }
                break;
        }
        
    }

   



    bool IsGround()
    {
        return Physics.CheckSphere(checkground.position, .4f, ground);
    }

    bool IsRun()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }

    public void IsClimb()
    {
        Debug.Log("isclimb");
        climbOn = false;
    }


}
