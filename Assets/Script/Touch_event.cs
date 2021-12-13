using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_event : MonoBehaviour
{
    Vector2 touchBeganPosition = new Vector2();
    Vector2 touchMovedPosition = new Vector2();

    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch _t = Input.GetTouch(0);

            if (_t.phase == TouchPhase.Began)
            {
                touchBeganPosition = _t.position;
            }
            if (_t.phase == TouchPhase.Moved)
            {
                touchMovedPosition = _t.position;
            }
            if(_t.phase == TouchPhase.Ended)
            {
                touchBeganPosition = Vector2.zero;
                touchMovedPosition = Vector2.zero;
            }
        }
        Debug.Log(direction());
      //  direction();
    }

    public int direction()
    {
        Vector2 f1 = touchMovedPosition - touchBeganPosition;

        if(f1.x < 0)
        {
            return -1;
        }
        else if(f1.x > 0)
        {
            return 1;
        }

        return 0;
    }
}
