using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitch : MonoBehaviour
{

    [SerializeField] private float laserUpTime = 4f;
    [SerializeField] private float laserDownTime = 2.5f;

    void Start()
    {
        Hide(); //starts the never ending cycle of death and rebirth
    }

    private void Show(){
        gameObject.SetActive(true); //re-enables the laser
        Invoke("Hide", laserUpTime); //calls the hide function after the up time is done
    }

    private void Hide(){
        gameObject.SetActive(false); //disables the laser
        Invoke("Show", laserDownTime); //also calls the show function after the lasers down time so that even when disabled, the laser will re-enable
    }
}
