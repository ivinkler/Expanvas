using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecenterBody : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x,this.transform.localPosition.y,0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x,this.transform.localPosition.y,0);
    }
}
