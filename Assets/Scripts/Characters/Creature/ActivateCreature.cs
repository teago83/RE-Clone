using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCreature : MonoBehaviour
{

    public GameObject Creature;
    public GameObject Song;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Creature.SetActive(true);
            Song.SetActive(true);
        }
    }
}
