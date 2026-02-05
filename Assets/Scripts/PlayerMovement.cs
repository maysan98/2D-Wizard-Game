
using UnityEngine;
using System.Collections;
using NUnit.Framework;
using UnityEngine.InputSystem.XR.Haptics;
using Unity.VisualScripting;
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
        

    

    void Update()
    {
        
        xAxis = Input.GetAxisRaw("Horizontal");              // حركة أفقي
        isGrounded = Mathf.Abs(rb.linearVelocityY) < 0.01f;

        
        if (Input.GetButtonDown("Jump") )
        {
            BufferCounter = BufferTime;//كل طلب قفز بينحفظ ل0.1 ثانيه اذا كان اللاعب عالارض خلال هذي الفتره بيقفز اذا لا رح يوصل الكاونتر لصفر وينمسح الطلب 
        }
        else BufferCounter -= Time.deltaTime;
        
    }     


    void FixedUpdate()
    {   
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
