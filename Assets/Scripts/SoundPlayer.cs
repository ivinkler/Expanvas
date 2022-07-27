using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] AudioSource soundPlayer;
    [SerializeField] bool loop;
    [SerializeField] bool autoPlay;
    [SerializeField] float pitch;

    // Start is called before the first frame update
    void Start()
    {
        
        soundPlayer = gameObject.GetComponent<AudioSource>();
        soundPlayer.loop = loop;
        //soundPlayer.autoPlay = autoPlay;
        pitch = soundPlayer.pitch;
    }


}
