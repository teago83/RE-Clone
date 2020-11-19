using System;
using UnityEngine;

public class ZombieState_Biting : ZombieState_Base
{

    public static event Action Bite;

    public override void OnCollisionEnter(ZombieAIFSM zScript, Collision col)
    {


    }

    public override void OnEnterState(ZombieAIFSM zScript)
    {

        Bite?.Invoke();
    }

    public override void Update(ZombieAIFSM zScript)
    {
    }
}
