using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Viewer : MonoBehaviour
{
    public bool IsSeeing;
    /* you'll need to find a way of making a condition for the zombie
     * to be shot by the player, making the zombie start to follow
     * the player while it can see the player */
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
