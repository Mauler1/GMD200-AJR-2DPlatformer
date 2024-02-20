using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float xSpeed = 10f; // player speed
    public float XSpeed => xSpeed; // speed getter - mostly for animations
    [SerializeField] private float jumpForce = 800f; // jumping force
    [SerializeField] private float dashForce = 20f; // dashing speed
    [SerializeField] private float dashTime = 0.15f; // time that dashing lasts for
    [SerializeField] private float dashCooldown = 1f; // cooldown between being able to dash
    [SerializeField] private float groundCheckRadius = 0.1f; // radius of ground checking circle
    [SerializeField] private LayerMask groundLayer; // ground
    [SerializeField] private TrailRenderer dashTrail; // dash trail
    private Rigidbody2D _rb; // player rigidbody
    private float _xMoveInput; // the x movement input
    private bool _isGrounded = true; // if player is grounded
    public bool IsGrounded => _isGrounded; // grounded getter - mostly for animations
    private bool _shouldJump; // if player should be able to jump
    private bool _shouldDash = true; // if player should be able to dash
    private bool _isDashing; // if player is currently dashing

    void Awake(){
        _rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {

        if(_isDashing){
            return; // if the player is currently dashing, it cannot perform any other input
        }

        _xMoveInput = Input.GetAxis("Horizontal") * xSpeed;
        if(Input.GetKeyDown(KeyCode.Space)){
            _shouldJump = true; // when jump is pressed, the player should jump
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && _shouldDash == true){
            StartCoroutine(CoDashing()); // when the shift button is pressed AND the player should be able to dash, call the dashing coroutine
        }
    }

    void FixedUpdate(){

        if(_isDashing){
            return; // if the player is currently dashing, it cannot perform any other input
        }

        Collider2D col = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer); //ground checking physics!!
        _isGrounded = col != null; //i love winebrenner tutorials
        _rb.velocity = new Vector2(_xMoveInput, _rb.velocity.y);
        if(_shouldJump){
            if(_isGrounded){
                _rb.AddForce(Vector2.up * jumpForce); //player can only jump when presssing the space bar and if on the ground
            }
            _shouldJump = false; //no auto jumping allowed
        }

    }

    private void OnCollisionEnter2D(Collision2D other){

        if(other.gameObject.CompareTag("MovingPlatform")){
            transform.SetParent(other.transform, true); //moving platform parenting so that the player moves along with it
        }

    }

    private void OnCollisionExit2D(Collision2D other){

        if(other.gameObject.CompareTag("MovingPlatform")){
            transform.SetParent(null, true); // removes the player as a child from the platform
        }

    }

    private IEnumerator CoDashing(){
        _shouldDash = false; // sets the should dash boolean to false so it cannot be called again until end of dashing and cooldown
        _isDashing = true; //currently dashing 
        float originalGravity = _rb.gravityScale;
        _rb.gravityScale = 0; // player cannot fall down while dashing
        _rb.velocity = new Vector2(transform.localScale.x * dashForce, 0f); // dash movement
        dashTrail.emitting = true; //starts trail when dashing
        yield return new WaitForSeconds(dashTime);
        dashTrail.emitting = false; //dashing is now done, set everything back
        _rb.gravityScale = originalGravity;
        _isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        _shouldDash = true; //after cooldown, should dash again
    }

    private void OnDrawGizmos(){ //gizmos for the ground check circle because i need to see
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, groundCheckRadius);
    }
}
