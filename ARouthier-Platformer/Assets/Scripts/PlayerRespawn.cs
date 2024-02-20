using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform respawn;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Hazard")){
            transform.position = respawn.position; //returns player back to the most recently touched checkpoint
        }
        else if(other.gameObject.CompareTag("Checkpoint")){
            respawn = other.transform; //sets checkpoints when player touches them
        }
    }
}
