using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleState : ZombieBaseState
{

    public override void EnterState(ZombieBehaviour_FSM Zombie)
    {
        Zombie.GetComponent<Animator>().Play("Idle");



        /*      Zombie.GetComponent<Animator>().Play("Idle");
                yield return new WaitForSeconds (WaitingTime);
                yield return StartCoroutine (TurnToFace (TargetWaypoint));*/
    }

    public override void OnCollisionEnter(ZombieBehaviour_FSM Zombie)
    {
        
    }

    public override void Update(ZombieBehaviour_FSM Zombie)
    {
        new WaitForSeconds(Zombie.WaitingTime);

//        Zombie.StartCoroutine(TurnToFace(TargetWaypoints);


        //Zombie.TransitionToState(Zombie.PatrolState);
    }
}
