using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySound : MonoBehaviour
{
    [SerializeField] AudioSource sound;

    void Start()
    {
        this.sound = this.gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            sound.Play();
        }
    }
}
