using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    PlayerState state;
    [HideInInspector] public bool hasWon;
    [SerializeField] GameObject finishLine;
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

        if (other.CompareTag("Finish"))
        {
            StartCoroutine(NextLevel());
            hasWon= true;
        }
    }

    void FreezePlayer(Collider2D playerCollider)
    {
        if (state.isFrozen) return;
        state.Freeze(2.5f);
        Debug.Log("freeze!");
    }
     
     IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
    
    
}