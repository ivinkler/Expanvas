using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchButtonBehavior : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonDown;

    // Start is called before the first frame update
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonDown = true;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        buttonDown = false;
    }
}
