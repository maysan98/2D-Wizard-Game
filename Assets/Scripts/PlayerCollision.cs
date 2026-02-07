using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    PlayerState state;
    void Start()
    {
        state = GetComponent<PlayerState>();
    }
     void OnTriggerEnter2D(Collider2D other)
    { 
        ProcessCollisions(other);
    }

    void ProcessCollisions(Collider2D other)
    {
        if (other.CompareTag("Bomb"))
        FreezePlayer(other);
    }

    void FreezePlayer(Collider2D playerCollider)
    {
        if (state.isFrozen) return;
        state.Freeze(2.5f);
        Debug.Log("freeze!");
    }
}
