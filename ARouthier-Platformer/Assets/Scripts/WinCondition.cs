using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        SceneManager.LoadScene("EndScene"); // if the player touches the win condition, display the end screen
    }
}
