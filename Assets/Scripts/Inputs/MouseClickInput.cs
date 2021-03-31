using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClickInput : InputCtrl, IPointerClickHandler, IPointerUpHandler
{
    private bool tempClicked = false;
    private bool isClicked = false;
    private float deltaClick = 0f;
    private float prevClickTime = 0f;
    private float prevDelta = 0f;
    public override bool Move()
    {
        if (tempClicked)
        {
            isClicked = tempClicked;
            tempClicked = false;            
        }
        else
            isClicked = false;
        return isClicked;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        deltaClick = eventData.clickTime - prevClickTime;
        if(deltaClick < 0.2f)
        {                      
            tempClicked = true;
        }
        prevClickTime = eventData.clickTime;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //isClicked = false;
    }
}
