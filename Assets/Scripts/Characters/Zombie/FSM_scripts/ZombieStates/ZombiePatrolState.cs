using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePatrolState : ZombieBaseState
{
    public override void EnterState(ZombieBehaviour_FSM Zombie)
    {
        Zombie.RandomSpot = Random.Range(0, Zombie.MoveSpots.Length);
        Zombie.GetComponent<Animator>().Play("Walking");
    }

    public override void OnCollisionEnter(ZombieBehaviour_FSM Zombie)
    {

    }

    public override void Update(ZombieBehaviour_FSM Zombie)
    {
        if (Vector3.Distance(Zombie.transform.position, Zombie.MoveSpots[Zombie.RandomSpot].position) < .2f && Zombie.HaveISeenThePlayer == false)
        {

            Zombie.WaitingTime = Zombie.StartWaitingTime;
            Zombie.TransitionToState(Zombie.IdleState);

        }
        else if (Zombie.HaveISeenThePlayer == false) 
        { 
            Zombie.transform.position = Vector3.MoveTowards(Zombie.transform.position, Zombie.MoveSpots[Zombie.RandomSpot].position, Zombie.Speed * Time.deltaTime); 
        }
        else
        {
            Zombie.TransitionToState(Zombie.CombatState);
        }
    }
}
