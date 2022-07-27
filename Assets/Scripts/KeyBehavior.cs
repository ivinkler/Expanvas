using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    [SerializeField] GameObject portal;
    [SerializeField] GameObject player;
    SphereCollider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = this.gameObject.GetComponent<SphereCollider>();
    }

}
