using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelTime : MonoBehaviour
{

    [SerializeField] GameObject textObject;
    private TextMeshProUGUI timeText;
    public int levelDuration = 30;
    private bool countingSeconds = false;
    [HideInInspector] public bool timeUp = false;


    void Start()
    {
        timeText = textObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {   
        timeText.text = " Time Left = " + levelDuration;

        if (levelDuration != 0 && countingSeconds == false)
        {
        StartCoroutine(Timer());
        } else if (levelDuration == 0)
        {
            timeUp = true;
            timeText.text = " Time UP! ";
            // Respawn()
        }
        

        
    }

    IEnumerator Timer()
    {  countingSeconds = true;
        yield return new WaitForSeconds(1);
        levelDuration -= 1;
        countingSeconds = false;
    }

}
