﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ZombieState_Patrolling : ZombieState_Base
{

    public static event Action IKilledPlayer;
    private Vector3 nextDestination;
    /*Teago remember: Ctrl + R + R to rename a variable and its uses.*/

    public override void OnEnterState(ZombieAIFSM zScript)
    {

        nextDestination = zScript.Waypoints[UnityEngine.Random.Range(0, zScript.Waypoints.Length)].position;
        zScript.aIController.SetDestination(nextDestination);
        zScript.animatorComp.SetBool("hasPath", true);

    }

    public override void Update(ZombieAIFSM zScript)
    {

        if (!zScript.aIController.hasPath) { zScript.ChangeState(zScript.statesIdle); }

        if (zScript.isSeeingPlayer)
        { /*Chase*/

            zScript.aIController.SetDestination(zScript.playerLocation);

            if (zScript.aIController.remainingDistance <= 6f)
            {

                /*Stopped here*/
                zScript.animatorComp.SetTrigger("strike");
                zScript.aIController.speed = 6;

            }
            else
            {

                zScript.aIController.speed = 3f;

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
