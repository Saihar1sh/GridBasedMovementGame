using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeInput : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown, isDragging = false;
    private Vector2 startTouch, swipeDelta;

    //Properties
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool IsDragging { get { return isDragging; } }



    // Update is called once per frame
    void Update()
    {
        tap = swipeRight = swipeLeft = swipeUp = swipeDown = false;

        Inputs();
        CalculateSwipeDistance();
    }

    private void Inputs()       //PC and Touch inputs
    {
        #region PC Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Reset();
        }
        #endregion

        #region Touch Inputs
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Reset();
            }
        }
        #endregion
    }

    private void Reset()        //Resetting the swipe distance
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }
    private void CalculateSwipeDistance()
    {
        swipeDelta = Vector2.zero;
        if (isDragging)
        {
            //calculating the distance of swipe performed
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        //checking if swipe exceeded the deadzone(no input will be considered if swipe is less than the zone)
        if (swipeDelta.magnitude > 50)         //Till 50 pixels is considered as deadzone
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))         //Movement in x axis
            {
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else                                   //Movement in y axis
            {
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;

            }
        }
    }


}
