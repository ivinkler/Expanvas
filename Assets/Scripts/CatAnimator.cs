using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatAnimator : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] GameObject parentBody;
    [SerializeField] bool flipped;
    [SerializeField] PlayerInput playerInput;


    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        parentBody = GameObject.Find("Pthalo_puppet");
        flipped = false;
        playerInput = gameObject.GetComponent<PlayerInput>();
    }

    public void AnimateMovement()
    {
        float xmove = playerInput.actions["Move"].ReadValue<float>();

         if(xmove < 0)
         {
             _anim.SetFloat("Speed",xmove);
             _anim.SetBool("isMoving",true);
             parentBody.transform.localScale = new Vector3(1, 1, 1);
             flipped = false;
         }
         else if(xmove > 0)
         {
             _anim.SetFloat("Speed",xmove);
             _anim.SetBool("isMoving",true);
             parentBody.transform.localScale = new Vector3(-1, 1, 1);
             flipped = true;
         }
         else
         {
             _anim.SetFloat("Speed",xmove);
             _anim.SetBool("isMoving",false);
         }
    }

    public void AnimateJump(bool grounded)
    {
        _anim.ResetTrigger("Jump");
        _anim.SetBool("isGrounded", grounded);
        if(grounded)
        {
            _anim.SetTrigger("Jump");
            _anim.SetBool("isGrounded",false);
        }
        else
        {
            _anim.SetTrigger("Jump");
        }
    }

    public void SetGrounded(bool grounded)
    {
        _anim.SetBool("isGrounded", grounded);
    }
}
