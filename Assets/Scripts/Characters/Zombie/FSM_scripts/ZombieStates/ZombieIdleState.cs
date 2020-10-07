using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleState : ZombieBaseState
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
        if (Zombie.WaitingTime > 0 && Zombie.HaveISeenThePlayer == false)
        {
            Zombie.WaitingTime -= Time.deltaTime;
        }
        else if (Zombie.HaveISeenThePlayer == false) 
        { 
            Zombie.TransitionToState(Zombie.PatrolState); 
        }
        else
        {
            Zombie.TransitionToState(Zombie.FollowingState);
        }
        if (Zombie.HitByPlayer == true)
        {
            Zombie.TransitionToState(Zombie.TakingDamageState);
        }
    }
}
