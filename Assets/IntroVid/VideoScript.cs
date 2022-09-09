using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        Invoke("HideVid",20);
    }

    void HideVid()
    {
        this.gameObject.SetActive(false);
    }
}
