using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCombatState : ZombieBaseState
{
    public override void EnterState(ZombieBehaviourFSM Zombie)
    {
        
    }

    public override void OnCollisionEnter(ZombieBehaviourFSM Zombie)
    {
        
    }

    public override void Update(ZombieBehaviourFSM Zombie)
    {
        // If the distance between the player and the zombie is smaller than or
        // equal to 2.3f, the zombie will attack the player.

        if (Vector3.Distance(Zombie.transform.position, Zombie.ThePlayer.transform.position) <= 2.75f)
        {
            Zombie.Anime.Play("Attacking");
        }

        // If the player is out of the zombie's reach, the zombie will start to
        // follow them.

        else
        {
            Zombie.TransitionToState(Zombie.FollowingState);
        }
    }
}
