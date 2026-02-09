
using UnityEngine;
using System.Collections;
using NUnit.Framework;
using UnityEngine.InputSystem.XR.Haptics;
using Unity.VisualScripting;
<<<<<<< Updated upstream
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpHeight = 5f;
    
    [SerializeField] float maskSpeed = 2f;
    [SerializeField] GameObject activeChar;

    [SerializeField] float Speed= 3f;
    private bool maskOn = false;
    private bool JumpPressed = false;
    private bool isGrounded;
    private float xAxis;
    private float BufferTime = 0.1f;
    private float BufferCounter;
    private string currentState;
    Animator anim;

    private Rigidbody2D rb;

    BombScript[] boxes;
    public Transform Skeletal;
=======
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

public class PlayerMovement : MonoBehaviour
{    [SerializeField] float jumpHeight = 5f;
    [SerializeField] GameObject activeChar;
    [SerializeField] float speed = 3f;
    [HideInInspector] public float xAxis;
    [HideInInspector] public Rigidbody2D rb;
    public Transform Skeletal;
    public bool isGrounded;
    private bool isJumpPressed; 
    private float bufferTime = 0.1f;
    private float bufferCounter;
    PlayerState state;
    [SerializeField] Transform rayCastOrigin;
    public LayerMask groundLayer;
    private RaycastHit2D Hit2D;

    
>>>>>>> Stashed changes

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = activeChar.GetComponent<Animator>(); 
        currentState = "Idle";
        anim.Play("Idle");
    }
     

    
    void ChangeAnimationState(string newState)
    {
        if(newState == currentState) return;
        anim.Play(newState);
        currentState = newState;
    }
        

    
    void GroundCheckMethod()
    {
        Hit2D = Physics2D.Raycast(rayCastOrigin.position , Vector2.down , 0.3f , groundLayer);
        if (Hit2D.collider != null)
        {
            isGrounded = true ;
        }
        else isGrounded = false;
    }


    void Update()
    {
        
<<<<<<< Updated upstream
        xAxis = Input.GetAxisRaw("Horizontal");              // حركة أفقي
        isGrounded = Mathf.Abs(rb.linearVelocityY) < 0.01f;

        
        if (Input.GetButtonDown("Jump") )
=======
        xAxis = Input.GetAxisRaw("Horizontal");              // Inputs
         
        isJumpPressed = Input.GetButtonDown("Jump");
        GroundCheckMethod();

        if (isJumpPressed )
>>>>>>> Stashed changes
        {
            BufferCounter = BufferTime;//كل طلب قفز بينحفظ ل0.1 ثانيه اذا كان اللاعب عالارض خلال هذي الفتره بيقفز اذا لا رح يوصل الكاونتر لصفر وينمسح الطلب 
        }
        else BufferCounter -= Time.deltaTime;
        
    }     


    void FixedUpdate()
    {   
<<<<<<< Updated upstream
        if (BufferCounter > 0 && isGrounded)      // قفز
                {
                    rb.linearVelocityY =  jumpHeight; 
                    BufferCounter = 0; // لأن خلاص قفز لهذا الطلب 
                    ChangeAnimationState("Jump");
                    return;
                }  


        rb.linearVelocity = new Vector2( xAxis * Speed , rb.linearVelocityY);

         

        
        
        if (!isGrounded && rb.linearVelocityY < 0)
            {
                ChangeAnimationState("Fall");
            }

        //Flip the charecter based on right and left movement
        if (rb.linearVelocityX < 0) 
            {
                Skeletal.localScale = new Vector3(-1,1,1);
            }
            else if (rb.linearVelocityX > 0)
            {
                Skeletal.localScale = new Vector3(1,1,1);
            }


        if (!isGrounded) // هنا اذا كان بالهواء اطلع من الفكسدابديت ولا تكمل الكود
        return;

        if (Mathf.Abs(rb.linearVelocityX) > 0.01f)
        ChangeAnimationState("Run");
        else
        ChangeAnimationState("Idle");
            
    } 
}
=======
        if (state.isFrozen) // if frozen stop moving.
        {
            rb.linearVelocity = Vector2.zero;  
            return;
        }


        
        if (bufferCounter > 0 && isGrounded)      // قفز
        {    
              rb.linearVelocityY = jumpHeight; 
              bufferCounter = 0; // لأن خلاص قفز لهذا الطلب 
                return;      
        }                    

        rb.linearVelocity = new Vector2(xAxis * speed , rb.linearVelocityY);

        //the main movement if on the ground 
        if (isGrounded && Hit2D.collider != null ){

            float slopeAngle = Vector2.Angle(Hit2D.normal , Vector2.up );
            if (slopeAngle >5f)//movement on a slope
            {  
                
                Vector2 slopeDirection = Vector2.Perpendicular(Hit2D.normal).normalized;

                if (slopeDirection.y > 0)// if its going upward make it downward and vice virsa 
                {
                    slopeDirection = -slopeDirection;
                }               
                 rb.linearVelocity = new Vector2( slopeDirection.x * xAxis * speed , rb.linearVelocityY) ; 

            }
        
            
            

         }
    }
}   
>>>>>>> Stashed changes
