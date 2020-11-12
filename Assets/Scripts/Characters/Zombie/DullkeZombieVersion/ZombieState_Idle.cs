using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieState_Idle : ZombieState_Base
{

    public override void OnEnterState(ZombieAIFSM zScript)
    {

        zScript.currentStillTime = zScript.stillTime;
        zScript.animatorComp.SetBool("hasPath", false);

    }

    public override void Update(ZombieAIFSM zScript)
    {

        //Wait time.
        //Patrol.
        //Detect Player.


        if (zScript.currentStillTime <= 0) { zScript.ChangeState(zScript.statesPatrol); }
        else { zScript.currentStillTime -= Time.deltaTime; }

        if (zScript.isSeeingPlayer) { zScript.ChangeState(zScript.statesPatrol); }

    }

    public override void OnCollisionEnter(ZombieAIFSM zScript)
    {

    }


}
