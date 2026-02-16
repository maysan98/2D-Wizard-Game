using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerState state;
    [SerializeField] AudioSource jumpSound; 


    // Update is called once per frame
    void Update()
    {
        if (playerMovement.isJumping)
            jumpSound.Play();
        

      
    }
}
