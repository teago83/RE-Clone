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

            Debug.Log(Vector3.Distance(zScript.playerLocation, zScript.transform.position));
            zScript.aIController.SetDestination(zScript.playerLocation);

        }

    }

    public override void OnCollisionEnter(ZombieAIFSM zScript)
    {
    }

}
