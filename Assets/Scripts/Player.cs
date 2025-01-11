using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 10f;
    public float jumpHeight = 10f;
    public float climbSpeed = 5f; 

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isTouchingWall;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Wall Check")]
    public Transform wallCheck;
    public float wallCheckRadius = 0.2f;
    public LayerMask wallLayer;

    private SpriteRenderer spriteRenderer;
    public Sprite people1;
    public Sprite people2;

    private bool isClimbing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleWallClimb();
    }

    void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");

        
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        
        if (moveInput > 0)
        {
            spriteRenderer.sprite = people1;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.sprite = people2;
        }
    }

    void HandleJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }

    void HandleWallClimb()
    {
        
        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, wallLayer);

        
        if (isTouchingWall && Input.GetKey(KeyCode.F))
        {
            isClimbing = true;
            rb.velocity = new Vector2(rb.velocity.x, climbSpeed);
            rb.gravityScale = 0; 
        }
        else
        {
            isClimbing = false;
            rb.gravityScale = 1; 
        }
    }

    void OnDrawGizmosSelected()
    {
        
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }

        
        if (wallCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(wallCheck.position, wallCheckRadius);
        }
    }
}
