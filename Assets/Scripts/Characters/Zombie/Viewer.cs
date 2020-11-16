using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Viewer : MonoBehaviour
{
    public bool IsSeeing;
    public UnityEvent NotSeeing;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsSeeing = false;
            Debug.Log("The zombie isn't seeing the player.");
            NotSeeing.Invoke();
        }
    }
}
