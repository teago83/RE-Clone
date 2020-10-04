using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingState : PlayerBaseState
{
    public override void EnterState(PlayerControlsFSM Player)
    {
        
    }

    public override void OnCollisionEnter(PlayerControlsFSM Player)
    {
        
    }

    public override void Update(PlayerControlsFSM Player)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Player.TransitionToState(Player.RunningState);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Player.WalkingForward = true;
            Player.WalkingBack = false;

        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Player.WalkingForward = true;
            Player.WalkingBack = false;

        }
        else if (Input.GetKey(KeyCode.S))
        {
            Player.WalkingForward = false;
            Player.WalkingBack = true;

        }
        else if (Input.GetMouseButton(1)) // Right mouse button being held
        {
            Player.TransitionToState(Player.AimingState);
        }

        // Animation-related ifs
        if (Player.WalkingForward == true)
        {
            Player.Anime.Play("Walk");
        }
        else if (Player.WalkingBack == true)
        {
            Player.Anime.Play("WalkBack");
        }

    }
}
