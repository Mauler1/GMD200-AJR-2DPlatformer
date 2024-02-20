using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float xSpeed = 10f;
    public float XSpeed => xSpeed;
    [SerializeField] private float jumpForce = 800f;
    [SerializeField] private float dashForce = 20f;
    [SerializeField] private float dashTime = 0.2f;
    [SerializeField] private float dashCooldown = 1f;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer dashTrail;
    private Rigidbody2D _rb;
    private float _xMoveInput;
    private bool _isGrounded = true;
    public bool IsGrounded => _isGrounded;
    private bool _shouldJump;
    private bool _shouldDash = true;
    private bool _isDashing;
    public bool IsDashing => _isDashing;

    void Awake(){
        _rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {

        if(_isDashing){
            return;
        }

        _xMoveInput = Input.GetAxis("Horizontal") * xSpeed;
        if(Input.GetKeyDown(KeyCode.Space)){
            _shouldJump = true;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && _shouldDash == true){
            StartCoroutine(CoDashing());
        }
    }

    void FixedUpdate(){

        if(_isDashing){
            return;
        }

        Collider2D col = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);
        _isGrounded = col != null;
        _rb.velocity = new Vector2(_xMoveInput, _rb.velocity.y);
        if(_shouldJump){
            if(_isGrounded){
                _rb.AddForce(Vector2.up * jumpForce);
            }
            _shouldJump = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D other){

        if(other.gameObject.CompareTag("MovingPlatform")){
            transform.SetParent(other.transform, true);
        }

    }

    private void OnCollisionExit2D(Collision2D other){

        if(other.gameObject.CompareTag("MovingPlatform")){
            transform.SetParent(null, true);
        }

    }

    private IEnumerator CoDashing(){
        _shouldDash = false;
        _isDashing = true;
        float originalGravity = _rb.gravityScale;
        _rb.gravityScale = 0;
        _rb.velocity = new Vector2(transform.localScale.x * dashForce, 0f);
        Debug.Log(dashForce);
        Debug.Log(transform.localScale.x);
        Debug.Log(_rb.velocity);
        dashTrail.emitting = true;
        yield return new WaitForSeconds(dashTime);
        dashTrail.emitting = false;
        _rb.gravityScale = originalGravity;
        _isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        _shouldDash = true;
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, groundCheckRadius);
    }
}
