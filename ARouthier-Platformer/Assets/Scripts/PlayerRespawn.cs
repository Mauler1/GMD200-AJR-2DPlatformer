using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform respawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Hazard")){
            transform.position = respawn.position;
        }
        else if(other.gameObject.CompareTag("Checkpoint")){
            respawn = other.transform;
        }
    }
}
