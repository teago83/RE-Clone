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

            /* these "WaitForSeconds" and the multiple calls for the Attacking 
            * animation were meant to be used as a pause in between the zombie's
            * attacks, but they didn't work. Keep them here for now. */

            //new WaitForSeconds(40);
            //Zombie.Anime.Play("Attacking");
            //new WaitForSeconds(4);
            //Zombie.Anime.Play("Attacking");
        }

        // If the player is out of the zombie's reach, the zombie will start to
        // follow them.

        else
        {
            Zombie.TransitionToState(Zombie.FollowingState);
        }
    }
}
