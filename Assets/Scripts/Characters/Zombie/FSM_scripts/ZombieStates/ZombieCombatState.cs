using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCombatState : ZombieBaseState
{
    public override void EnterState(ZombieBehaviourFSM Zombie)
    {
        Zombie.AttackingDistance = 12f;
        Zombie.PlayerCurrentHealth = PlayerFSM.Health;
    }

    public override void OnCollisionEnter(ZombieBehaviourFSM Zombie)
    {
        
    }

    public override void Update(ZombieBehaviourFSM Zombie)
    {
        // If the distance between the player and the zombie is quite small, the zombie will attack the player.

        if (Vector3.Distance(Zombie.transform.position, PlayerFSM.CurrentPosition) <= Zombie.AttackingDistance && Zombie.InFrontOfPlayer == true)
        {
            Zombie.Anime.Play("Attacking");
            if (Zombie.PlayerCurrentHealth == PlayerFSM.Health && Zombie.AttackingSFXCooldown <= 6.1f)
            {
                Zombie.TransitionToState(Zombie.FollowingState);
            }
        }

        // If the player is out of the zombie's reach, the zombie will start to
        // follow them.

        else
        {
            Zombie.TransitionToState(Zombie.FollowingState);
        }

        // If the player dies, the zombie shall remain still and stop trying
        // to follow the player.
        if (PlayerFSM.Health <= 0)
        {
            Zombie.TransitionToState(Zombie.NoPointState);
        }
        if (Zombie.HitByPlayer == true)
        {
            Zombie.TransitionToState(Zombie.TakingDamageState);
        }
    }
}
