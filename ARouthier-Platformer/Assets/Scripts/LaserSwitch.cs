using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitch : MonoBehaviour
{

    [SerializeField] private float laserUpTime = 4f;
    [SerializeField] private float laserDownTime = 2.5f;
    [SerializeField] private BoxCollider2D laser;

    // Start is called before the first frame update
    void Start()
    {
        laser = gameObject.GetComponent<BoxCollider2D>();
        Hide();
    }

    private void Show(){
        gameObject.SetActive(true);
        Invoke("Hide", laserUpTime);
    }

    private void Hide(){
        gameObject.SetActive(false);
        Invoke("Show", laserDownTime);
    }
}
