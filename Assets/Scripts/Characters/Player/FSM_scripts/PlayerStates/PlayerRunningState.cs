﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
    public override void EnterState(PlayerControlsFSM Player)
    {
        
    }

    public override void OnCollisionEnter(PlayerControlsFSM Player)
    {
        
    }

    public override void Update(PlayerControlsFSM Player)
    {
        if (Player.WalkingForward == true && Input.GetKey(KeyCode.LeftShift))
        {
            Player.Anime.Play("Run");
            Player.ForwardMovement = Input.GetAxis("Vertical") * Time.deltaTime * 10f;
            Player.RotationalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * 165f;
            
            if (Input.GetKey(KeyCode.S))
            {
                Player.WalkingForward = false;
                Player.TransitionToState(Player.WalkingState);
            }
            
            Player.transform.Translate(0, 0, Player.ForwardMovement);
            Player.transform.Rotate(0, Player.RotationalMovement, 0);
        }
        else if (Input.GetMouseButton(1))
        {
            Player.TransitionToState(Player.AimingState);
        }
        else if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            Player.TransitionToState(Player.WalkingState);
        }
        else
        {
            Player.TransitionToState(Player.IdleState);
        }
    }
}
