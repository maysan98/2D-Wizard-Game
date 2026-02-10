using UnityEngine;

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
