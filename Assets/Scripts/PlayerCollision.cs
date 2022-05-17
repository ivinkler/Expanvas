using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject key;
    [SerializeField] GameObject portal;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
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
             Debug.Log("Collision Detected");
         }
     }

    void Vanish()
    {
        player.SetActive(false);
    }

     void ExitLevel()
     {
        
     }
}
