using System.Collections;
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
            if (Input.GetKey(KeyCode.W))
            {
                Player.Anime.Play("Run");
                Player.ForwardMovement = Input.GetAxis("Vertical") * Time.deltaTime * 12f;
                Player.RotationalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * 175f;

                if (Input.GetKey(KeyCode.S))
                {
                    Player.WalkingForward = false;
                    Player.TransitionToState(Player.WalkingState);
                }

                Player.transform.Translate(0, 0, Player.ForwardMovement);
                Player.transform.Rotate(0, Player.RotationalMovement, 0);
            }
            else
            {
                Player.TransitionToState(Player.IdleState); 
            }
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
