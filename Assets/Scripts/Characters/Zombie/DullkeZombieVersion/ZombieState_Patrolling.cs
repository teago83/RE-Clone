using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieState_Patrolling : ZombieState_Base
{


    public override void OnEnterState(ZombieAIFSM zScript)
    {

        Vector3 nextDestination = zScript.Waypoints[Random.Range(0, zScript.Waypoints.Length)].position;
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
            if (col.gameObject.GetComponent<PlayerFSM>().isAlive == false)
            {

                zScript.animatorComp.SetBool("isPlayerDead", true);
                zScript.aIController.enabled = false;
                zScript.GetComponent<ZombieAIFSM>().enabled = false;
                zScript.GetComponent<CapsuleCollider>().enabled = false;


            }
            else { zScript.ChangeState(zScript.statesBiting); }

        }

    }

}
