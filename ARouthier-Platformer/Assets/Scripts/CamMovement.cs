using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField] private Transform[] camPoints;
    private int _screenIndex = 0;
    private Transform _currentPoint;

    // Refactored moving platform code - camera moves to different points when called
    void Start()
    {
        //sets a current point and moves the camera to it
        _currentPoint = camPoints[_screenIndex];
        transform.position = _currentPoint.position;
    }

    public void newScreen(){
        //increases the index and sets the next point 
        _screenIndex++;
        _currentPoint = camPoints[_screenIndex];
        transform.position = _currentPoint.position; // sets the camera position to the current point
        //could not use movetowards because it would offset the camera z-value and not display anything
    }
}
