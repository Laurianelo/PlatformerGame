using Microsoft.Win32.SafeHandles;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float groundCheckRadius;

    public Rigidbody2D rb;
    public Transform groundCheck;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public LayerMask collisionLayer;

    private bool isJumping;
    private bool isGrounded;
    private float horizontalMovement;
    private Vector3 velocity = Vector3.zero;


    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    // not the best solution, bug with unity if in update, i don't have another solutions for the moment
    void FixedUpdate()
    {
        
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;//

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayer);

        MovePlayer(horizontalMovement);
    }

    private void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    private void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if( _velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
