using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Detector : MonoBehaviour
{
    public bool IsInRange;
    public UnityEvent Detection;

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsInRange = true;
            Debug.Log("The zombie is seeing the player.");
            Detection.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsInRange = false;
            Debug.Log("The zombie isn't seeing the player.");
            /* Find a way of leaving the combat state after the player
             * isn't in the zombie's range anymore */
        }
    }
}
