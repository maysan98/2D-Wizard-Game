using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerState playerState;
    [SerializeField] GameObject dieScreen;
    [SerializeField] GameObject wonScreen;
    [SerializeField] PlayerCollision playerCollision;


    
    void Update()
    {
        if (playerState.isDead)
        {
            dieScreen.SetActive(true);
        }

        if (playerCollision.hasWon)
        {
            wonScreen.SetActive(true);
        }
    }

    
}
