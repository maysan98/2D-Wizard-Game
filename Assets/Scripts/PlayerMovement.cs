using UnityEngine;
using System.Collections;
using NUnit.Framework;
using UnityEngine.InputSystem.XR.Haptics;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] GameObject activeChar;
    [SerializeField] float speed = 3f;
    public bool isGrounded;
    private bool isJumpPressed;
    [HideInInspector] public float xAxis;
    private float bufferTime = 0.1f;
    private float bufferCounter;
   
    public Rigidbody2D rb;
    public Transform Skeletal;
    
    PlayerState state;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = GetComponent<PlayerState>();
    }
    

    void Update()
    {
        if (state.isFrozen) return; // Early exit so it doesn't accept inputs if it is frozen
        
        xAxis = Input.GetAxisRaw("Horizontal");              // Inputs
        isGrounded = Mathf.Abs(rb.linearVelocityY) < 0.01f;
        isJumpPressed = Input.GetButtonDown("Jump");


        if (isJumpPressed )
        {
            bufferCounter = bufferTime;  //كل طلب قفز بينحفظ ل0.1 ثانيه اذا كان اللاعب عالارض خلال هذي الفتره بيقفز اذا لا رح يوصل الكاونتر لصفر وينمسح الطلب 
        }
        else bufferCounter -= Time.deltaTime;
        
    }     


    void FixedUpdate()
    {   
        if (state.isFrozen)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        if (bufferCounter > 0 && isGrounded)      // قفز
        {    
              rb.linearVelocityY =  jumpHeight; 
              bufferCounter = 0; // لأن خلاص قفز لهذا الطلب 
                return;      
        }                    


        rb.linearVelocity = new Vector2(xAxis * speed , rb.linearVelocityY);

    } 
    
}
    