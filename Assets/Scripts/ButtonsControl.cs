using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsControl : MonoBehaviour
{
    public void StartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);//goes to level 1 
    }

    public void QuitGame()
    {
        Application.Quit();//only works in the built.
    }
}
