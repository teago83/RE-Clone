using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePatrolState : ZombieBaseState
{
    public override void EnterState(ZombieBehaviourFSM Zombie)
    {
        Zombie.RandomSpot = Random.Range(0, Zombie.MoveSpots.Length);
        Zombie.Anime.Play("Walking");
    }

    public override void OnCollisionEnter(ZombieBehaviourFSM Zombie)
    {

    }

    public override void Update(ZombieBehaviourFSM Zombie)
    {
        if (Vector3.Distance(Zombie.transform.position, Zombie.MoveSpots[Zombie.RandomSpot].position) < .2f && Zombie.HaveISeenThePlayer == false)
        {

            Zombie.WaitingTime = Zombie.StartWaitingTime;
            Zombie.TransitionToState(Zombie.IdleState);

        }
        else if (Zombie.HaveISeenThePlayer == false) 
        {
            // Below lies some code to make the zombie look at the target that it should be facing
            // and said target shall be the next RandomSpot.
            // Source: https://docs.unity3d.com/ScriptReference/Vector3.RotateTowards.html

            Vector3 TargetDirection = Zombie.MoveSpots[Zombie.RandomSpot].transform.position - Zombie.transform.position;
            Vector3 NewDirection = Vector3.RotateTowards(Zombie.transform.forward, TargetDirection, Zombie.RegularSpeed * Time.deltaTime, 0.0f);
            Zombie.transform.rotation = Quaternion.LookRotation(NewDirection);

            Zombie.transform.position = Vector3.MoveTowards(Zombie.transform.position, Zombie.MoveSpots[Zombie.RandomSpot].position, Zombie.RegularSpeed * Time.deltaTime); 

            if (Zombie.HitByPlayer == true)
            {
                Zombie.TransitionToState(Zombie.TakingDamageState);
            }
        }
        else
        {
            Zombie.TransitionToState(Zombie.FollowingState);
        }
    }
}
