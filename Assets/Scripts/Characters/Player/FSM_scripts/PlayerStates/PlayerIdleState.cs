using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerFSM Player)
    {
        Player.Anime.Play("Idle");
    }

    public override void OnCollisionEnter(PlayerFSM Player)
    {
        
    }

    public override void Update(PlayerFSM Player)
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
            Player.TransitionToState(Player.WalkingState);
        }

        else if (Input.GetMouseButton(1))
        {
            Player.TransitionToState(Player.AimingState);
        }
    }
}
