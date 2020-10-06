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
        // If the distance between the player and the zombie is quite small, the zombie will attack the player.

        if (Vector3.Distance(Zombie.transform.position, Zombie.ThePlayer.transform.position) <= 4.5f && Zombie.InFrontOfPlayer == true)
        {
            Zombie.Anime.Play("Attacking");
        }

        // If the player is out of the zombie's reach, the zombie will start to
        // follow them.

        else
        {
            Zombie.TransitionToState(Zombie.FollowingState);
        }

        // If the player dies, the zombie shall remain still and stop trying
        // to follow the player.
        if (Zombie.ThePlayer.GetComponent<PlayerFSM>().Health <= 0)
        {
            Zombie.TransitionToState(Zombie.NoPointState);
        }
        if (Zombie.HitByPlayer == true)
        {
            Zombie.TransitionToState(Zombie.TakingDamageState);
        }
    }
}
