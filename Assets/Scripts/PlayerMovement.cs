using Microsoft.Win32.SafeHandles;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public float jumpForce;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private bool isJumping;
    private bool isGrounded;

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
     
        float horizontalMovement = Input.GetAxis("Horizontal") *  moveSpeed * Time.deltaTime;

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        MovePlayer(horizontalMovement);

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
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
}
