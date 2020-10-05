using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Detector : MonoBehaviour
{
    public bool IsSeeing;
    public UnityEvent Detection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsSeeing = true;
            Debug.Log("The zombie is seeing the player.");
            Detection.Invoke();
        }
    }
}
