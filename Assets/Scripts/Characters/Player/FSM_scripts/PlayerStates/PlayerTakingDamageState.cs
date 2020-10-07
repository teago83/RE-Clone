using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakingDamageState : PlayerBaseState
{
    public override void EnterState(PlayerFSM Player)
    {
        Player.TakingDamageWaitTime = .5f;
    }
    public override void OnCollisionEnter(PlayerFSM Player)
    {

    }
    public override void Update(PlayerFSM Player)
    {
        if (Player.DamageCooldown <= 0)
        {
            Player.Health -= 50;

            if (Player.AttackFromTheFront == true)
            {
                Player.Anime.Play("Damage1");
            }
            else if (Player.AttackFromTheBack == true)
            {
                Player.Anime.Play("Damage2");
            }
            
            Debug.Log("Player's current health: " + Player.Health);
            Player.DamageCooldown = 1.3f;
        }

        if (Player.TakingDamageWaitTime <= 0)
        {
            Player.TransitionToState(Player.IdleState);
        }
        else
        {
            Player.TakingDamageWaitTime -= Time.deltaTime;
        }
        
    }
}
