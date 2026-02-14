
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

public class AnimationManager : MonoBehaviour
{
    Animator anim;
    private string currentState;
    PlayerMovement move;
    PlayerState state;
    [SerializeField] LevelTime timeState;
    void Start()
    {
        move = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
        state = GetComponent<PlayerState>();

    }

    void Update()
    {
        if (state.isFrozen)
        {
            ChangeAnimationState("Hurt");
            return;
        }

        if (timeState.timeUp)
        {
            ChangeAnimationState("Die");
            return;
        }

        Flip();

        if (!move.isGrounded){
            if (move.rb.linearVelocityY > 0.01f )
            ChangeAnimationState("Jump");
            else ChangeAnimationState("Idle");
        }
        else if (Mathf.Abs(move.rb.linearVelocityX) > 0.01f)
        ChangeAnimationState("Run");
        else
        ChangeAnimationState("Idle");

    } 
    public void ChangeAnimationState(string newState)
    {
        if(newState == currentState) return;
        anim.Play(newState);
        currentState = newState;
    }

    void Flip()
    {
        //Flip the charecter based on right and left movement
        if (move.xAxis < 0) 
            {
                move.Skeletal.localScale = new Vector3(-1,1,1);
            }
            else if (move.xAxis > 0)
            {
                move.Skeletal.localScale = new Vector3(1,1,1);
            }
    }
      
}