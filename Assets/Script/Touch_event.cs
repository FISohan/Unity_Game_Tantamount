using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_event : MonoBehaviour
{
    Vector2 touchBeganPosition = new Vector2();
    Vector2 touchMovedPosition = new Vector2();
    Vector2 currentPositionDelta = new Vector2();

    public GameObject trail;
    void FixedUpdate()
    {

        if (Input.touchCount > 0)
        {
            Touch _t = Input.GetTouch(0);

            if (_t.phase == TouchPhase.Began)
            {
                touchBeganPosition = _t.position;
            }
            if(_t.phase == TouchPhase.Moved)
            {
                Vector3 p = Camera.main.ScreenToWorldPoint(_t.position);
                trail.transform.position = new Vector2(p.x, p.y);
            }
            if(_t.phase == TouchPhase.Ended)
            {
                touchMovedPosition = _t.position;
                currentPositionDelta = touchMovedPosition - touchBeganPosition;

                if(currentPositionDelta.x < 0)
                {
                    Debug.Log("left");
                    FindObjectOfType<GameLogic>().pawnMove(-1);
                }else if(currentPositionDelta.x > 0)
                {
                    Debug.Log("right");
                    FindObjectOfType<GameLogic>().pawnMove(1);
                }
            }

           // Debug.Log(currentPositionDelta);
        }
       // Debug.Log(direction());
      //  direction();
    }


}
