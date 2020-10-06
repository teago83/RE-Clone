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
        if (PlayerFSM.CurrentWeapon == 0)
        {
            Zombie.Health -= PlayerFSM.PistolDamage;
        }
        
    }
}
