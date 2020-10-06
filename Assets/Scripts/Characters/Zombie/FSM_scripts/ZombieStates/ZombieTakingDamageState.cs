using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTakingDamageState : ZombieBaseState
{
    public override void EnterState(ZombieBehaviourFSM Zombie)
    {
        Zombie.TakingDamageWaitTime = .3f;    
    }

    public override void OnCollisionEnter(ZombieBehaviourFSM Zombie)
    {
        
    }

    public override void Update(ZombieBehaviourFSM Zombie)
    {
        Zombie.Anime.Play("Hit");

        if (Zombie.ThePlayer.GetComponent<PlayerFSM>().CurrentWeapon == 0)
        {
            Zombie.Health -= PlayerFSM.PistolDamage;
        }
        else if (Zombie.ThePlayer.GetComponent<PlayerFSM>().CurrentWeapon == 1)
        {
            Zombie.Health -= PlayerFSM.ShotgunDamage;
        }

        if (Zombie.TakingDamageWaitTime <= 0)
        {
            Zombie.HitByPlayer = false;
            Zombie.TransitionToState(Zombie.IdleState);
        }
        else
        {
            Zombie.TakingDamageWaitTime -= Time.deltaTime;
        }
    }
}
