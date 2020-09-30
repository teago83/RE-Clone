using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleState : ZombieBaseState
{

    public override void EnterState(ZombieBehaviour_FSM Zombie)
    {
        Zombie.GetComponent<Animator>().Play("Idle");
    }

    public override void OnCollisionEnter(ZombieBehaviour_FSM Zombie)
    {

    }

    public override void Update(ZombieBehaviour_FSM Zombie)
    {
       

        //if (Vector3.Distance(Zombie.transform.position, Zombie.MoveSpots[Zombie.RandomSpot].position) < .2f)
        //{
        //    Zombie.WaitingTime -= Time.deltaTime;
        //}

        if (Zombie.WaitingTime > 0)
        {

            Zombie.WaitingTime -= Time.deltaTime;

        }
        else { Zombie.TransitionToState(Zombie.PatrolState); }

        // if (Vector3.Distance (Zombie.transform.position, Zombie.MoveSpots[Zombie.RandomSpot].position) < .2f);
    }

    /* O zumbi espere
     * waiting time = 0
     * ir pra patrol
     */



}
