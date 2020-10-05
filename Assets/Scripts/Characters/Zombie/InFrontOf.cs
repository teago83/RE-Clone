using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InFrontOf : MonoBehaviour
{
    
    public bool IsInRange;
    public UnityEvent InFrontOfThePlayer;
    public UnityEvent NotInFrontOfThePlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsInRange = true;
            Debug.Log("The zombie is in front of the player.");
            InFrontOfThePlayer.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsInRange = false;
            Debug.Log("The zombie isn't in front of the player.");
            NotInFrontOfThePlayer.Invoke();
        }
    }
}
