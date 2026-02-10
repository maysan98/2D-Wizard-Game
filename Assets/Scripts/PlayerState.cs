
using UnityEngine;
using System.Collections;
public class PlayerState : MonoBehaviour // class for player's states
{
    [HideInInspector] public bool isFrozen = false;
    [SerializeField] LevelTime timeState;
    [HideInInspector] public bool isDead;
    void Update()
    {
        if (timeState.timeUp)
        {
            isDead = true;
        }
    }
    public void Freeze(float duration)
    {
        StartCoroutine(FreezeCoroutine(duration));
    }

    IEnumerator FreezeCoroutine(float duration)
    { 
        if (isFrozen) yield break;
        
        isFrozen = true;
        yield return new WaitForSeconds(duration);
        isFrozen = false;
    
    }



    
}