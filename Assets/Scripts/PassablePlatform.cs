using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassablePlatform : MonoBehaviour
{
    [SerializeField] BoxCollider trigger;
    [SerializeField] MeshCollider mesh;
    [SerializeField] Material mat1;
    [SerializeField] Material mat2;

    // Start is called before the first frame update
    void Start()
    {
        this.trigger = this.gameObject.GetComponent<BoxCollider>();
        this.mesh = this.gameObject.GetComponent<MeshCollider>();
        this.mat1 = 
        this.mat2 = 
        this.GetComponent<Renderer>().material = mat1;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            mesh.enabled = false;
            this.GetComponent<Renderer>().material = mat2;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            mesh.enabled = true;
            this.GetComponent<Renderer>().material = mat1;
        }
    }


}
