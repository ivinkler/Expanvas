using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatBehavior : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] GameObject parentBody;
    [SerializeField] bool flipped;
    [SerializeField] PlayerInput playerInput;


    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        parentBody = GameObject.Find("Cat_Model");
        flipped = false;
        playerInput = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        float xmove = playerInput.actions["Move"].ReadValue<float>();

         if(xmove < 0)
         {
             _anim.SetFloat("Speed",xmove);
             parentBody.transform.localScale = new Vector3(1, 1, 1);
             flipped = false;
         }
         else if(xmove > 0)
         {
             _anim.SetFloat("Speed",xmove);
             parentBody.transform.localScale = new Vector3(-1, 1, 1);
             flipped = true;
         }
         else
         {
             _anim.SetFloat("Speed",0);
         }
    }
}
