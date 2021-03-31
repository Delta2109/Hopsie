using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : InputCtrl
{
    private float clickTime = 0f;
    private float deltaClickTime = 0f;
    private float prevClickTime = 0f;
    public override bool Move()
    {
        clickTime += Time.deltaTime;
        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                deltaClickTime = clickTime - prevClickTime;
                if (deltaClickTime < 0.2f)
                {                
                    return true;
                }
                prevClickTime = clickTime;
            }         
        }
        return false;
    }
}
