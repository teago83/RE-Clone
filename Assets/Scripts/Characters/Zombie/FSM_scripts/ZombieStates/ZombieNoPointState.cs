using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNoPointState : ZombieBaseState
{
    public override void EnterState(ZombieBehaviourFSM Zombie)
    {
        Zombie.animatorComp.Play("Idle");
    }

    public override void OnCollisionEnter(ZombieBehaviourFSM Zombie)
    {
        
    }

    public override void Update(ZombieBehaviourFSM Zombie)
    {
        
    }
}
