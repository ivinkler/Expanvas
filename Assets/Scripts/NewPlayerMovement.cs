using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class NewPlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpPower = 5f;
    [SerializeField] int extraJumps = 1;
    [SerializeField] float gravity = 9.81f;
    [SerializeField] float scaleFactor = 0.1f;
    [SerializeField] Vector3 gravityDirection = new Vector3(0,-1,0);
    [SerializeField] Transform relativeTransform;
    int remainingJumps;
    Vector3 localVector;

    [SerializeField] Rigidbody rigidbody;

    bool isGrounded = false;
    [SerializeField] LayerMask ground;
    [SerializeField] Transform feet;
    [SerializeField] float groundCheckRadius;

    [SerializeField] float recallGrounded = 0.1f;
    float lastGrounded;

    [SerializeField] float fallMultiplier = 2.5f; 
    [SerializeField] float lowJumpMultiplier = 2f;

    [SerializeField] PlayerInput playerInput;

    //[SerializeField] bool useTouchControls;

    //[SerializeField] GameObject leftButton;
    //[SerializeField] GameObject rightButton;
    //[SerializeField] GameObject jumpButton;
    //[SerializeField] GameObject jumpButton2;

    [SerializeField] GameObject key;
    [SerializeField] GameObject portal;

    // Start is called before the first frame update
    void Start()
    {
        remainingJumps = extraJumps+1;
        rigidbody.useGravity = false;
        groundCheckRadius = 0.015f;
        playerInput = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Body").GetComponent<Renderer>().isVisible)
        {
            Vector3 downVector = this.transform.TransformDirection((gravityDirection * (scaleFactor*gravity) * rigidbody.mass));
            rigidbody.AddRelativeForce(downVector);
            localVector = transform.InverseTransformDirection(rigidbody.velocity);
            Move();
            GroundCheck();
            Jump();
            JumpExtra();
            ResetZ();
        }
    }

    void Move()
    {
        float x;
        x = playerInput.actions["Move"].ReadValue<float>();
        float xMove = x*speed;

        rigidbody.velocity = this.transform.TransformDirection(new Vector3(xMove,localVector.y,0));
        //rigidbody.velocity = new Vector3(xMove,rigidbody.velocity.y,velocity.z);
        localVector = transform.InverseTransformDirection(rigidbody.velocity);
    }

    void Jump()
    {
        if(playerInput.actions["Jump"].triggered && (isGrounded || Time.time - lastGrounded <= recallGrounded || remainingJumps > 0 ))
        {
            //Vector3 tempMove = new Vector3(rigidbody.velocity.x,jumpPower,0);
            rigidbody.velocity = this.transform.TransformDirection(new Vector3(localVector.x,jumpPower,0));
            //rigidbody.AddRelativeForce(tempMove);
            remainingJumps--;
            localVector = transform.InverseTransformDirection(rigidbody.velocity);
        }
    }

    void JumpExtra()
    {
        if (rigidbody.velocity.y < 0) 
        {
            rigidbody.velocity += this.transform.TransformDirection(gravityDirection * (fallMultiplier - 1) * Time.deltaTime);
            //rigidbody.AddRelativeForce(gravityDirection * (fallMultiplier - 1) * Time.deltaTime);
        } 
        else if (rigidbody.velocity.y > 0 && !(playerInput.actions["Jump"].triggered)) 
        {
            rigidbody.velocity += this.transform.TransformDirection(gravityDirection * (lowJumpMultiplier - 1) * Time.deltaTime);
            //rigidbody.AddRelativeForce(gravityDirection * (lowJumpMultiplier - 1) * Time.deltaTime);
        }
        localVector = transform.InverseTransformDirection(rigidbody.velocity);
    }

    void GroundCheck()
    {
        bool grounded = Physics.CheckSphere(feet.position,groundCheckRadius,ground);
        if(grounded)
        {
            this.isGrounded = true;
            this.remainingJumps = extraJumps+1;
        }
        else
        {
            if(isGrounded)
            {
                lastGrounded = Time.time;
            }
        }
        this.isGrounded = false;
    }

    void ResetZ()
    {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x,this.transform.localPosition.y,0);
    }

}

