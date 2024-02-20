using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement playerMovement;
    private bool _facingRight = true;
    
    void Awake(){
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_facingRight && _rb.velocity.x < -0.1){
            Flip();
        }
        else if(!_facingRight && _rb.velocity.x > 0.1){
            Flip();
        }
        animator.SetFloat("MoveSpeedX", Mathf.Abs(_rb.velocity.x)/playerMovement.XSpeed); //setting values for the animators - the positive x velocity divided by the players speed value
        animator.SetBool("Grounded", playerMovement.IsGrounded); // is player on da ground
    }

    private void Flip(){ //flips the player depending on the player's direction
        _facingRight = !_facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
