using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool IsInRange;
    public KeyCode InteractKey;
    public UnityEvent Interaction;
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (IsInRange)
        {
            if (Input.GetKeyDown(InteractKey) && Player.GetComponent<PlayerFSM>().OnCutscene == false) // If the player presses the interact key while not on a cutscene...
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerInteractionFOV"))
        {
            IsInRange = false;
        }
    }
}
