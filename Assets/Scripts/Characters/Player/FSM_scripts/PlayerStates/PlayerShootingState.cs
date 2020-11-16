using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingState : PlayerBaseState
{
    public override void EnterState(PlayerFSM Player)
    {

    }


    public override void OnCollisionEnter(PlayerFSM Player, Collision col)
    {

    }

    public override void Update(PlayerFSM Player)
    {

        if (Player.FiringAnimationCooldown > 0f)
        {
            Player.FiringAnimationCooldown -= Time.deltaTime;
        }
        else
        {
            Player.TransitionToState(Player.AimingState);
        }
    }
}
