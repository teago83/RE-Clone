using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Script used to detect where an attack might have come from. 

public class DamageDetector : MonoBehaviour
{
    public UnityEvent WhereTheAttackCameFrom;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ZombieHand"))
        {
            Debug.Log("The zombie has successfully hit the player!");
            WhereTheAttackCameFrom.Invoke();
        }
    }
}
