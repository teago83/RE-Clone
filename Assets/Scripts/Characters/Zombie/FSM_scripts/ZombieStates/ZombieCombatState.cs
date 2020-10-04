using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCombatState : ZombieBaseState
{
    public override void EnterState(ZombieBehaviourFSM Zombie)
    {
        Zombie.Anime.Play("Walking");
    }

    public override void OnCollisionEnter(ZombieBehaviourFSM Zombie)
    {
        
    }

    public override void Update(ZombieBehaviourFSM Zombie)
    {
        // Zombie starts attacking the player
        if (Vector3.Distance(Zombie.transform.position, Zombie.ThePlayer.transform.position) < .2f && Zombie.HaveISeenThePlayer == true)
        {
            // Implement zombie attacking the player and decreasing their health
        }
        else if (Zombie.HaveISeenThePlayer == true)
        {
            // Code for the zombie to rotate towards the player

            Vector3 TargetDirection = Zombie.ThePlayer.transform.position - Zombie.transform.position;
            Vector3 NewDirection = Vector3.RotateTowards(Zombie.transform.forward, TargetDirection, Zombie.Speed * Time.deltaTime, 0.0f);
            Zombie.transform.rotation = Quaternion.LookRotation(NewDirection);

            Zombie.transform.position = Vector3.MoveTowards(Zombie.transform.position, Zombie.ThePlayer.transform.position, Zombie.Speed * Time.deltaTime);
        }
        else
        {
            Zombie.transform.position = Vector3.MoveTowards(Zombie.transform.position, Zombie.MoveSpots[Zombie.RandomSpot].position, Zombie.Speed * Time.deltaTime);
            Zombie.TransitionToState(Zombie.PatrolState);
        }
    }
}
