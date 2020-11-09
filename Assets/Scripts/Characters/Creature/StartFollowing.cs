using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFollowing : MonoBehaviour
{

    public GameObject Creature;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Creature.GetComponent<KillNDestroy>().CanFollow = true;
        }
    }
}
