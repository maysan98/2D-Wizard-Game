using UnityEngine;
using System.Collections;
using NUnit.Framework;
using UnityEngine.InputSystem.XR.Haptics;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float speed = 3f;
    [HideInInspector] public float xAxis;
    public bool isGrounded;
    private bool isJumpPressed;
    PlayerState state;
    private float bufferTime = 0.1f;
    private float coyoteTimer;
    private float coyoteTime = 0.1f;

    

    private float bufferCounter;
    public Rigidbody2D rb;
    public Transform Skeletal;
    [HideInInspector] public bool isJumping;

    [SerializeField] LayerMask groundMask;
    [SerializeField] GameObject rayCastOrigin;
    RaycastHit2D hit;
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = GetComponent<PlayerState>();
    }

    void Update()
    {
        if (state.isDead) return; 
        if (state.isFrozen) return; // Early exit so it doesn't accept inputs if it is frozen

        xAxis = Input.GetAxisRaw("Horizontal");              // Inputs
        IsGrounded();
        isJumpPressed = Input.GetButtonDown("Jump");

        if (isJumpPressed)
            bufferCounter = bufferTime;
        else
           {bufferCounter -= Time.deltaTime;} 

        if (IsGrounded())
        {
            coyoteTimer = coyoteTime;
        } else coyoteTimer -= Time.deltaTime;

    }

    void FixedUpdate()
    {
        if (state.isDead)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocityY);
            rb.gravityScale= 2f;
            return;
        }
        
        
        if (state.isFrozen)
        {
            rb.linearVelocity = Vector2.zero; 
            return;
        }

        
        if (bufferCounter > 0 && coyoteTimer > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX , jumpHeight);
            bufferCounter = 0;
            coyoteTimer = 0;
            isJumping = true; 
            return;
        } else isJumping = false;

        
        
       


        rb.linearVelocity = new Vector2(xAxis * speed, rb.linearVelocityY);
    }

    public bool IsGrounded()
    {
        float groundCheckDistance = 0.5f;
        hit =  Physics2D.Raycast(rayCastOrigin.transform.position, Vector2.down , groundCheckDistance , groundMask);
        return hit.collider != null;

        
    }
}
