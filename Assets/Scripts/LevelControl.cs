using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    [SerializeField] PlayerState state;
    
        void Update()
    {
        if (state.isDead)
        {
            StartCoroutine(Respawn());
        }
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    


}
