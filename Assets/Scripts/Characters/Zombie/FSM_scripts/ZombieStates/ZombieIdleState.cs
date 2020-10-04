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
       

        //if (Vector3.Distance(Zombie.transform.position, Zombie.MoveSpots[Zombie.RandomSpot].position) < .2f)
        //{
        //    Zombie.WaitingTime -= Time.deltaTime;
        //}

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
            Zombie.TransitionToState(Zombie.CombatState);
        }

        // if (Vector3.Distance (Zombie.transform.position, Zombie.MoveSpots[Zombie.RandomSpot].position) < .2f);
    }

    /* O zumbi espere
     * waiting time = 0
     * ir pra patrol
     */



}
