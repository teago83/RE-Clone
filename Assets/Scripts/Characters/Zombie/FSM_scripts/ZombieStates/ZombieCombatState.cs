using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCombatState : ZombieBaseState
{
    public override void EnterState(ZombieBehaviourFSM Zombie)
    {
        Zombie.Anime.Play("Idle");
    }

    public override void OnCollisionEnter(ZombieBehaviourFSM Zombie)
    {
        
    }

    public override void Update(ZombieBehaviourFSM Zombie)
    {

    }
}
