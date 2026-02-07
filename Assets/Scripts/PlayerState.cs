using UnityEngine;
using System.Collections;
public class PlayerState : MonoBehaviour // class for player's states
{
    [HideInInspector] public bool isFrozen = false;
    
        
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
