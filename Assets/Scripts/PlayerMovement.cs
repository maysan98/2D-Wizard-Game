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
    private float bufferCounter;
    public Rigidbody2D rb;
    public Transform Skeletal;
    [HideInInspector] public bool isJumping;
    
    

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
        isGrounded = Mathf.Abs(rb.linearVelocityY) < 0.01f;
        isJumpPressed = Input.GetButtonDown("Jump");

        if (isJumpPressed)
            bufferCounter = bufferTime;
        else
            bufferCounter -= Time.deltaTime;
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

        
        if (bufferCounter > 0 && isGrounded)
        {
            rb.linearVelocityY = jumpHeight;
            bufferCounter = 0;
            isJumping = true; 
            return;
        } else isJumping = false;

        
        
       


        rb.linearVelocity = new Vector2(xAxis * speed, rb.linearVelocityY);
    }
}
