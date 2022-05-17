using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehavior : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.RotateAround(transform.position,transform.forward,Time.deltaTime*rotationSpeed);
    }

}
