using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    public bool IsInRange;
    public KeyCode InteractKey;
    public UnityEvent Interaction;

    // Update is called once per frame
    void Update()
    {
        if (IsInRange)
        {
            if (Input.GetKeyDown(InteractKey)) // If the player presses the interact key...
            {
                Interaction.Invoke(); // ...the event is triggered.
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerInteractionFOV"))
        {
            IsInRange = true;
            Debug.Log("The player is now in range.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerInteractionFOV"))
        {
            IsInRange = false;
            Debug.Log("The player isn't in range anymore.");
        }
    }
}
