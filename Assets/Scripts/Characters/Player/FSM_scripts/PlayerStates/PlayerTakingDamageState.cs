using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakingDamageState : PlayerBaseState
{
    public override void EnterState(PlayerFSM Player)
    {
        Player.TakingDamageWaitTime = .3f;
    }
    public override void OnCollisionEnter(PlayerFSM Player)
    {

    }
    public override void Update(PlayerFSM Player)
    {
        Player.Health -= 1;

        if (Player.AttackFromTheFront == true)
        {
            Player.Anime.Play("Damage1");
        }
        else if (Player.AttackFromTheBack == true)
        {
            Player.Anime.Play("Damage2");
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
