using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCreature : MonoBehaviour
{

    public GameObject Creature;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Creature.SetActive(true);
            // Insert a "start creepy-creature song" piece of code here
        }
    }
}
