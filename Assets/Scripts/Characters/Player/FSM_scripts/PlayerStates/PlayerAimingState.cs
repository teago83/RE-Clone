using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimingState : PlayerBaseState
{
    public override void EnterState(PlayerControlsFSM Player)
    {
        Player.Anime.Play("Aiming SniperRifle");
    }

    public override void OnCollisionEnter(PlayerControlsFSM Player)
    {
        
    }

    public override void Update(PlayerControlsFSM Player)
    {
        if (Input.GetMouseButton(1))
        {
            Player.Anime.Play("Aiming SniperRifle");
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            Player.TransitionToState(Player.RunningState);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Player.TransitionToState(Player.WalkingState);
        }
        else
        {
            Player.TransitionToState(Player.IdleState);
        }
    }
}
