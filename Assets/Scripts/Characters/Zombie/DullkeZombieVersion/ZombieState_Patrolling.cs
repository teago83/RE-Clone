using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ZombieState_Patrolling : ZombieState_Base
{

    public static event Action IKilledPlayer;
    private Vector3 nextDestination;
    private GameObject Player;
    /*Teago remember: Ctrl + R + R to rename a variable and its uses.*/

    public override void OnEnterState(ZombieAIFSM zScript)
    {

        nextDestination = zScript.Waypoints[UnityEngine.Random.Range(0, zScript.Waypoints.Length)].position;
        zScript.aIController.SetDestination(nextDestination);
        zScript.animatorComp.SetBool("hasPath", true);

    }

    public override void Update(ZombieAIFSM zScript)
    {

        Player = GameObject.FindGameObjectWithTag("Player");

        if (!zScript.aIController.hasPath) 
        {
            zScript.isSeeingPlayer = false;
            zScript.ChangeState(zScript.statesIdle); 
        }

        if (zScript.isSeeingPlayer)
        { /*Chase*/

            zScript.aIController.SetDestination(Player.transform.position);

            if (zScript.aIController.remainingDistance <= 6f)
            {

                /*Stopped here*/
                zScript.animatorComp.SetTrigger("strike");
                zScript.aIController.speed = 6;

            }
            else if (zScript.aIController.remainingDistance <= 35f)
            {

                zScript.aIController.speed = 3f;

            }
            else if (zScript.aIController.remainingDistance > 35f)
            {
                zScript.aIController.SetDestination(nextDestination);
                zScript.isSeeingPlayer = false;
            }
        }
    }

    public override void OnCollisionEnter(ZombieAIFSM zScript, Collision col)
    {


        if (col.collider.CompareTag("Player"))
        {

            if (PlayerFSM.isAlive == false)
            {

                Debug.Log("Player is now dead");
                #region ZombieCode
                //zScript.aIController.enabled = false;
                //zScript.GetComponent<ZombieAIFSM>().enabled = false;
                //zScript.GetComponent<CapsuleCollider>().enabled = false;
                //zScript.GetComponent<Rigidbody>().freezeRotation = true; 
                #endregion

            }
            else { zScript.ChangeState(zScript.statesBiting); }
        }

    }


}
