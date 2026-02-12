using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerState playerState;
    [SerializeField] GameObject dieScreen;

    
    void Update()
    {
        if (playerState.isDead)
        {
            dieScreen.SetActive(true);
        }

    }

    
}
