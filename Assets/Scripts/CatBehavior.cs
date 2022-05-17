using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehavior : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] GameObject leftButton;
    [SerializeField] GameObject rightButton;
    [SerializeField] GameObject parentBody;
    [SerializeField] bool flipped;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        leftButton = GameObject.Find("LeftButton");
        rightButton = GameObject.Find("RightButton");
        parentBody = GameObject.Find("Cat_Model");
        flipped = false;
    }

    // Update is called once per frame
    void Update()
    {
         if(leftButton.GetComponent<TouchButtonBehavior>().buttonDown || Input.GetAxis("Horizontal") < 0)
         {
             _anim.SetFloat("Speed",1);
             parentBody.transform.localPosition = new Vector3(0.4f, 0.05f, 0f);
             parentBody.transform.localScale = new Vector3(-1, 1, 1);
             flipped = true;
         }
         else if(rightButton.GetComponent<TouchButtonBehavior>().buttonDown || Input.GetAxis("Horizontal") > 0)
         {
             _anim.SetFloat("Speed",1);
             parentBody.transform.localPosition = new Vector3(-0.4f, 0.05f, 0f);
             parentBody.transform.localScale = new Vector3(1, 1, 1);
             flipped = false;
         }
         else
         {
             _anim.SetFloat("Speed",0);
         }
    }
}
