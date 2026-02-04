using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{

    [SerializeField] GameObject timeBox;
    [SerializeField] bool takingSeconds = false;
    [SerializeField] int timeLeft = 20;
    //[SerializeField] GameObject timeUp;
    [SerializeField] bool isRespawning = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeBox.GetComponent<TMPro.TMP_Text>().text = "Time Left: " + timeLeft;
        if (takingSeconds == false)// Starts the timer if it's not already running
        {
             StartCoroutine(Timer()); 
        }

        if (timeLeft == 0 && isRespawning == false) // When time runs out
        {
            isRespawning = true; 
            takingSeconds = true;
            
            //timeUp.SetActive(true);
            
            StartCoroutine(Respawn());
        } 
    }
        IEnumerator Timer() // Counts down the time left by 1 every second
            {  
                takingSeconds = true;
                yield return new WaitForSeconds(1);
                timeLeft -= 1;
                takingSeconds = false;
            }
             IEnumerator Respawn()// Respawns the player after 3 seconds when time is up
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(
                SceneManager.GetActiveScene().name
            );
    }
    
}
