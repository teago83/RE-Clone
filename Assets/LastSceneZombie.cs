using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LastSceneZombie : MonoBehaviour
{

    private NavMeshAgent aiController;
    private GameObject playerObj;
    private Animator animComponent;


    void Start()
    {
        animComponent = GetComponent<Animator>();
        aiController = GetComponent<NavMeshAgent>();
        playerObj = GameObject.FindGameObjectWithTag("Player");
        animComponent.SetBool("hasPath", true);
    }

    void Update()
    {

        aiController.SetDestination(playerObj.transform.position);
        if (aiController.remainingDistance <= 6f)
        {

            /*Stopped here*/
            animComponent.SetTrigger("strike");
            aiController.speed = 6;

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {

            //Do whatever you want here teago.

        }

    }

}
