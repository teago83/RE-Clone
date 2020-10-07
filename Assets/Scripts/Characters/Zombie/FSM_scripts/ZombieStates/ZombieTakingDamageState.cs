using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTakingDamageState : ZombieBaseState
{
    public override void EnterState(ZombieBehaviourFSM Zombie)
    {
        Zombie.TakingDamageWaitTime = Zombie.StartTakingDmgWaitTime;
    }

    public override void OnCollisionEnter(ZombieBehaviourFSM Zombie)
    {
        
    }

    public override void Update(ZombieBehaviourFSM Zombie)
    {
        while (Zombie.TakingDamageWaitTime > 0)
        {
            Zombie.Anime.Play("Hit");
        }

        if (Zombie.CanBeHit == true)
        {
            Zombie.HitByPlayer = false;
            
            if (Zombie.ThePlayer.GetComponent<PlayerFSM>().CurrentWeapon == 0)
            {
                Zombie.Health -= PlayerFSM.PistolDamage;
            }
            else if (Zombie.ThePlayer.GetComponent<PlayerFSM>().CurrentWeapon == 1)
            {
                Zombie.Health -= PlayerFSM.ShotgunDamage;
            }

            Zombie.CanBeHit = false;
        }

        if (Zombie.TakingDamageWaitTime > 0)
        {
            Zombie.TakingDamageWaitTime -= Time.deltaTime;
        }

        else
        {
            Zombie.CanBeHit = true;
            Zombie.HaveISeenThePlayer = true;
            Zombie.TransitionToState(Zombie.IdleState);
        }

        /*if (Zombie.TakingDamageWaitTime <= 0 && Zombie.HitByPlayer == true)
        {
            if (Zombie.ThePlayer.GetComponent<PlayerFSM>().CurrentWeapon == 0)
            {
                Zombie.Health -= PlayerFSM.PistolDamage;
            }
            else if (Zombie.ThePlayer.GetComponent<PlayerFSM>().CurrentWeapon == 1)
            {
                Zombie.Health -= PlayerFSM.ShotgunDamage;
            }
            Zombie.TakingDamageWaitTime = Zombie.StartTakingDmgWaitTime;
            Zombie.HitByPlayer
        }
        
        if (Zombie.TakingDamageWaitTime <= 0)
        {
            Zombie.HitByPlayer = false;
            Zombie.TransitionToState(Zombie.IdleState);
        }
        else
        {
            Zombie.TakingDamageWaitTime -= Time.deltaTime;
        }*/
    }
}
