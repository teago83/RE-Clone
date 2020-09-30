using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePatrolReference : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;

    private int randomSpot;

    private void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector3.Distance (transform.position, moveSpots[randomSpot].position) < .2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

}



// TUTORIAL USED AS A BASIS FOR CREATING THIS SCRIPT:
// https://youtu.be/8eWbSN2T8TE