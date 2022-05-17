using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
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

    [SerializeField] bool useTouchControls;

    [SerializeField] GameObject leftButton;
    [SerializeField] GameObject rightButton;
    [SerializeField] GameObject jumpButton1;
    [SerializeField] GameObject jumpButton2;

    [SerializeField] GameObject key;
    [SerializeField] GameObject portal;

    bool jumpButtonPressed;

    // Start is called before the first frame update
    void Start()
    {
        remainingJumps = extraJumps+1;
        rigidbody.useGravity = false;
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
        if(useTouchControls)
        {
            if(rightButton.GetComponent<TouchButtonBehavior>().buttonDown)
            {
                x = 1;
            }
            else if(leftButton.GetComponent<TouchButtonBehavior>().buttonDown)
            {
                x = -1;
            }
            else
            {
                x = 0;
            }
        }
        else
        {
            x = Input.GetAxis("Horizontal");
        }
        float xMove = x*speed;

        rigidbody.velocity = this.transform.TransformDirection(new Vector3(xMove,localVector.y,0));
        //rigidbody.velocity = new Vector3(xMove,rigidbody.velocity.y,velocity.z);
        localVector = transform.InverseTransformDirection(rigidbody.velocity);
    }

    void Jump()
    {
        jumpButtonPressed = ((jumpButton1.GetComponent<TouchButtonBehavior>().buttonDown) || (jumpButton2.GetComponent<TouchButtonBehavior>().buttonDown));

        if((Input.GetButtonDown("Jump") || jumpButtonPressed) && (isGrounded || Time.time - lastGrounded <= recallGrounded || remainingJumps > 0 ))
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
        else if (rigidbody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
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

    void OnTriggerEnter(Collider other) 
    {
         if (other.tag == "Exit") 
         {
             Debug.Log("Hit Portal!");
             Invoke("ExitLevel", 1.5f);
             Invoke("Vanish",0.5f);
         }
         else if(other.tag == "Key")
         {
             Debug.Log("Hit Key!");
             key.SetActive(false);
             portal.SetActive(true);
         }
         else
         {
             //Do nothing
         }
     }

    void Vanish()
    {
        this.gameObject.SetActive(false);
    }

     void ExitLevel()
     {
        
     }
}
