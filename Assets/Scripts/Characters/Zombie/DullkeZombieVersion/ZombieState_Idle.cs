using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieState_Idle : ZombieState_Base
{

    public override void OnEnterState(ZombieAIFSM zScript)
    {

        zScript.aIController.speed = 3f;
        zScript.currentStillTime = zScript.stillTime;
        zScript.animatorComp.SetBool("hasPath", false);

    }

    public override void Update(ZombieAIFSM zScript)
    {

        if (zScript.currentStillTime <= 0) { zScript.ChangeState(zScript.statesPatrol); zScript.zombieMoans.Play(); }
        else { zScript.currentStillTime -= Time.deltaTime; }

        if (zScript.isSeeingPlayer) { zScript.ChangeState(zScript.statesPatrol); }

    }

    public override void OnCollisionEnter(ZombieAIFSM zScript, Collision col)
    {

        //do something

    }


}
