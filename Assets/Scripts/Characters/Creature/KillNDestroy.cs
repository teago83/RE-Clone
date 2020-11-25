using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillNDestroy : MonoBehaviour
{

    public GameObject Creature;
    private double FollowTimer;
    public bool CanFollow = false;
    private float ForwardMovement = -5;

    private void Start()
    {
        FollowTimer = 1;
    }

    private void Update()
    {
        if (CanFollow && PlayerFSM.Health > 0)
        {
            if (FollowTimer >= -1)
            {
                FollowTimer -= Time.deltaTime;
            }
            if (FollowTimer < 0)
            {
                Creature.transform.Translate(ForwardMovement, 0, 0);
                FollowTimer = 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lamp"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            PlayerFSM.Health = 0;
        }
    }
}
