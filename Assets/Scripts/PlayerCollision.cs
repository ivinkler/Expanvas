using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject key;
    [SerializeField] GameObject portal;
    [SerializeField] GameObject start;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        player = GameObject.Find("Key");
        player = GameObject.Find("Portal");
        player = GameObject.Find("StartMarker");
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
         else if(other.tag == "Killbox")
         {
             Debug.Log("Hit killbox");
             player.transform.position = start.transform.position; 
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
     }
}
