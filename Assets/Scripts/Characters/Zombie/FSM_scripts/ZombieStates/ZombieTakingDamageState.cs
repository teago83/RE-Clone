using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTakingDamageState : ZombieBaseState
{
    public override void EnterState(ZombieBehaviourFSM Zombie)
    {
        Zombie.Anime.Play("Walking");
        Zombie.TakingDamageCooldown = Zombie.StartTakingDmgCooldown;
    }

    public override void OnCollisionEnter(ZombieBehaviourFSM Zombie)
    {
        
    }

    public override void Update(ZombieBehaviourFSM Zombie)
    {
        if (Zombie.CanBeHit == true)
        {
            Zombie.TakingDamageSFX.Play();
            Zombie.HitByPlayer = false;
            
            if (PlayerFSM.CurrentWeapon == 0)
            {
                Zombie.Health -= PlayerFSM.PistolDamage;
                
            }
            else if (PlayerFSM.CurrentWeapon == 1)
            {
                Zombie.Health -= PlayerFSM.ShotgunDamage;   
            }

            Zombie.CanBeHit = false;
        }

        if (Zombie.TakingDamageCooldown > 0)
        {
            Zombie.TakingDamageCooldown -= Time.deltaTime;
        }

        else
        {
            Zombie.CanBeHit = true;
            Zombie.HaveISeenThePlayer = true;
            Zombie.TransitionToState(Zombie.FollowingState);
        }
    }
}
