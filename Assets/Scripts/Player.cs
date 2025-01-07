using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 10f;
    public float jumpHeight = 10f;

    private Rigidbody2D rb;
    private bool isGrounded;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    
    private SpriteRenderer spriteRenderer;
    public Sprite people1;  
    public Sprite people2;   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
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
}
