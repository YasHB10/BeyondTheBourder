using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class controls the gestuares detection
/// </summary>
public class SwipeCtrl : MonoBehaviour {

    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private Vector2 startTouch, swipeDelta;
    private bool isDraging = true;

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool SwipeUp { get { return swipeUp; } }

    private void Update()
    {
        tap = swipeLeft = swipeRight = swipeDown = swipeUp = false;
        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        //Calculate distance
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        // Did we cross the deadzone
        if (swipeDelta.magnitude > 125)
        {
            //  which direction ?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                // Left or Right
                if (x < 0f)
                {
                    swipeLeft = true;
                    swipeRight = false;
                    swipeUp = false;
                    swipeDown = false;
                }
                else
                {
                    swipeLeft = false;
                    swipeRight = true;
                    swipeUp = false;
                    swipeDown = false;
                }

            }
            else
            {
                // Up or Down
                if (y < 0f)
                {
                    swipeLeft = false;
                    swipeRight = false;
                    swipeUp = false;
                    swipeDown = true;
                }
                else
                {
                    swipeLeft = false;
                    swipeRight = false;
                    swipeUp = true;
                    swipeDown = false;
                }
            }
            Reset();
        }

    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}
