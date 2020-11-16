using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieState_Biting : ZombieState_Base
{
    public override void OnCollisionEnter(ZombieAIFSM zScript, Collision col)
    {


    }

    public override void OnEnterState(ZombieAIFSM zScript)
    {

        zScript.animatorComp.SetBool("hitPlayer", true);
        zScript.zombieAttack.Play();
        zScript.aIController.ResetPath();
        Debug.Log("I'm biting nhom nhom");

    }

    public override void Update(ZombieAIFSM zScript)
    {
    }
}
