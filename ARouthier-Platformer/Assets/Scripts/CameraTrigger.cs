using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] CamMovement sceneCamera; // camera movement script, not camera
    [SerializeField] GameObject obstacle; // the barrier that is activated to stop the player from backtracking

    private void OnTriggerEnter2D(Collider2D other){
        // if the player triggers the camrea move threshold
        if(other.gameObject.CompareTag("Player")){
            sceneCamera.newScreen(); // moves camera to next point
            obstacle.SetActive(true); // sets the barrier to true to stop player backtracking
            gameObject.SetActive(false); // disables the trigger so that it cannot be called again on an already activated threshold
        }
    }
}
