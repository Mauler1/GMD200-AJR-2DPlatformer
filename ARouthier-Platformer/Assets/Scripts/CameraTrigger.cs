using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] CamMovement sceneCamera;
    [SerializeField] GameObject obstacle;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("hit!");
            sceneCamera.newScreen();
            obstacle.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
