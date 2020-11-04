using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollowingState : ZombieBaseState
{
    public override void EnterState(ZombieBehaviourFSM Zombie)
    {
<<<<<<< Updated upstream
        Zombie.Anime.Play("Walking");
        Zombie.AttackingDistance = 5.5f;
=======
        Zombie.animatorComp.SetTrigger("Walking");
        Zombie.AttackingDistance = 5f;
>>>>>>> Stashed changes
    }

    public override void OnCollisionEnter(ZombieBehaviourFSM Zombie)
    {

    }

    public override void Update(ZombieBehaviourFSM Zombie)
    {
        // Zombie goes into its combat state in order to attack the player.
        if (Vector3.Distance(Zombie.transform.position, PlayerFSM.CurrentPosition) <= Zombie.AttackingDistance && Zombie.HaveISeenThePlayer == true && Zombie.InFrontOfPlayer == true)
        {
            Zombie.TransitionToState(Zombie.CombatState);
        }
        else if (Zombie.HaveISeenThePlayer == true)
        {
            // Code for the zombie to rotate and move towards the player.

            Vector3 TargetDirection = PlayerFSM.CurrentPosition - Zombie.transform.position;
            Vector3 NewDirection = Vector3.RotateTowards(Zombie.transform.forward, TargetDirection, Zombie.FollowingSpeed * Time.deltaTime, 0.0f);
            Zombie.transform.rotation = Quaternion.LookRotation(NewDirection);

            Zombie.transform.position = Vector3.MoveTowards(Zombie.transform.position, PlayerFSM.CurrentPosition, Zombie.FollowingSpeed * Time.deltaTime);
        }
        else
        {
            Zombie.transform.position = Vector3.MoveTowards(Zombie.transform.position, Zombie.MoveSpots[Zombie.RandomSpot].position, Zombie.FollowingSpeed * Time.deltaTime);
            Zombie.TransitionToState(Zombie.PatrolState);
        }
        if (Zombie.HitByPlayer == true)
        {
            Zombie.TransitionToState(Zombie.TakingDamageState);
        }
    }
}
