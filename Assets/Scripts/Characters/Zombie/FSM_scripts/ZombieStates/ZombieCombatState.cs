using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCombatState : ZombieBaseState
{
    public override void EnterState(ZombieBehaviour_FSM Zombie)
    {
        Zombie.GetComponent<Animator>().Play("Walking");
    }

    public override void OnCollisionEnter(ZombieBehaviour_FSM Zombie)
    {
        
    }

    public override void Update(ZombieBehaviour_FSM Zombie)
    {
        // Zombie starts attacking the player
        if (Vector3.Distance(Zombie.transform.position, Zombie.ThePlayer.transform.position) < .2f && Zombie.HaveISeenThePlayer == true)
        {
            // Implement zombie attacking the player and decreasing their health
        }
        else if (Zombie.HaveISeenThePlayer == true)
        {
            Zombie.transform.position = Vector3.MoveTowards(Zombie.transform.position, Zombie.ThePlayer.transform.position, Zombie.Speed * Time.deltaTime);
        }
        else
        {
            Zombie.TransitionToState(Zombie.PatrolState);
        }
    }
}
