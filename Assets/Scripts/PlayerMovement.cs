
using UnityEngine;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpHeight = 5f;
    
    [SerializeField] float maskSpeed = 2f;
    [SerializeField] GameObject activeChar;

    [SerializeField] float Speed= 3f;
    private bool maskOn = false;
    Animator anim;

    private Rigidbody2D rb;

    BombScript[] boxes;
    public Transform Skeletal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = activeChar.GetComponent<Animator>(); 
        
    }

    void Update()
    {
        bool isGrounded = rb.linearVelocityY == 0;
        float x = Input.GetAxis("Horizontal");              // حركة أفقي
        rb.linearVelocity = new Vector2( x * Speed , rb.linearVelocityY);
        
        if ( Mathf.Abs(rb.linearVelocityX) > 0.01 ) //  اذا على الارض ويتحرك افقيا شغل انيميشن الركض 
            { 
                anim.SetBool("isRun", true); 
            } 
            else
            {
                anim.SetBool("isRun", false);
            }    


        if (rb.linearVelocityX < 0)
        {
            Skeletal.localScale = new Vector3(-1,1,1);
        } else if(rb.linearVelocityX > 0)
         {
            Skeletal.localScale = new Vector3(1,1,1);
        }

        
        if (Input.GetButtonDown("Jump") && isGrounded)      // قفز
        {
            rb.linearVelocityY =  jumpHeight; 
            anim.SetTrigger( "isJump"); 
        }   
    }     
          

}

// إيجاد كل الصناديق
        //boxes = GameObject.FindObjectsByType<BombScript>(FindObjectsSortMode.None);

// الماسك
        /* if (Input.GetKeyDown(KeyCode.M) && !maskOn)
        {
            StartCoroutine(UseMask());
        }

        // التفاعل مع الصناديق
        if (boxes != null)
        {
            foreach (BombScript box in boxes)
            {
                if (box != null)
                    box.CheckMask(maskOn);
            }
        }*/
    /*IEnumerator UseMask()
    {
        maskOn = true;
        currentSpeed = maskSpeed;
        
        Debug.Log("MASK ON");

        yield return new WaitForSeconds(3f);

        maskOn = false;
        currentSpeed = normalSpeed;
        
        Debug.Log("MASK OFF");
    }*/

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        BombScript box = collision.gameObject.GetComponent<BombScript>();
        if (box != null && box.hasBomb && !maskOn)
        {
            Debug.Log("Boom! Restart Level");
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
            );
        }
    }*/

