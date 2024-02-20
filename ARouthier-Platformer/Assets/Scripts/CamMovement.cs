using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField] private Transform[] camPoints;
    private int _screenIndex = 0;
    private Transform _currentPoint;

    // Start is called before the first frame update
    void Start()
    {
        _currentPoint = camPoints[_screenIndex];
        transform.position = _currentPoint.position;
    }

    public void newScreen(){
        _screenIndex++;
        _currentPoint = camPoints[_screenIndex];
        transform.position = _currentPoint.position;
    }
}
