using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    private bool _tap, _swipeLeft, _swipeRight, _swipeUp, _swipeDown;
    private bool IsDragging;
    private Vector2 _startTouch, _swipeLength;
    private void Update()
    {
        _tap = _swipeLeft = _swipeRight = _swipeUp = _swipeDown = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            IsDragging = true;
            _tap = true;
            _startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            IsDragging = false;
            Reset();
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                IsDragging = true;
                _tap = true;
                _startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                IsDragging = false;
                Reset();
            }
        }
        #endregion

        //calculate the distance
        _swipeLength = Vector2.zero;

        if (IsDragging)
        {
            if (Input.touches.Length > 0)//if there are more than 1 touch at the same time
            {
                _swipeLength = Input.touches[0].position - _startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                _swipeLength = (Vector2)Input.mousePosition - _startTouch;
            }
        }

        if (_swipeLength.magnitude > 100)//if we exit from deadzone 
        {
            //which direction we are going?
            float x = _swipeLength.x;
            float y = _swipeLength.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))//we are going horizontal //left or right
            {
                if (x < 0)
                    _swipeLeft = true;
                else
                    _swipeRight = true;
            }
            else//we are going vertical //up or right
            {
                if (y < 0)
                    _swipeDown = true;
                else
                    _swipeUp = true;
            }
        }
    }
    private void Reset()
    {
        _startTouch = _swipeLength = Vector2.zero;
        IsDragging = false;
        _tap = false;
    }
    public Vector2 SwipeDelta { get { return _swipeLength; } }
    public bool SwipeLeft { get { return _swipeLeft; } }
    public bool SwipeRight { get { return _swipeRight; } }
    public bool SwipeUp { get { return _swipeUp; } }
    public bool SwipeDown { get { return _swipeDown; } }
    public bool Tap { get { return _tap; } }

}
