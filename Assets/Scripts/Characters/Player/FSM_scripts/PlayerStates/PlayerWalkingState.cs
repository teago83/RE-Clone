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
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) 
            {
                Player.WalkingForward = true;
                Player.Anime.Play("Walk"); 

                if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
                {
                    Player.TransitionToState(Player.RunningState);
                }

            }

            else if (Input.GetKey(KeyCode.S)) 
            {
                Player.WalkingForward = false;
                Player.Anime.Play("WalkBack"); 
            }

            Player.ForwardMovement = Input.GetAxis("Vertical") * Time.deltaTime * 6f;
            Player.RotationalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * 120f;
            Player.transform.Translate(0, 0, Player.ForwardMovement);
            Player.transform.Rotate(0, Player.RotationalMovement, 0);
        }

        else if (Input.GetMouseButton(1))
        {
            Player.TransitionToState(Player.AimingState);
        }

        else
        {
            Player.TransitionToState(Player.IdleState);
        }
    }
}
