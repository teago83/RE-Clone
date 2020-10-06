using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
    public override void EnterState(PlayerFSM Player)
    {
        
    }

    public override void OnCollisionEnter(PlayerFSM Player)
    {
        
    }

    public override void Update(PlayerFSM Player)
    {
        if (Player.WalkingForward == true && Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.W))
            {
                Player.Anime.Play("Run");
                Player.ForwardMovement = Input.GetAxis("Vertical") * Time.deltaTime * 12f;
                Player.RotationalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * 175f;

                Player.transform.Translate(0, 0, Player.ForwardMovement);
                Player.transform.Rotate(0, Player.RotationalMovement, 0);

                if (Input.GetMouseButton(1))
                {
                    Player.TransitionToState(Player.AimingState);
                }
                else if (Player.AttackFromTheFront == true || Player.AttackFromTheBack == true)
                {
                    Player.TransitionToState(Player.TakingDamageState);
                }
                
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Player.WalkingForward = false;
                Player.TransitionToState(Player.WalkingState);
            }
            else
            {
                Player.TransitionToState(Player.IdleState);
            }
        }

        else if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            Player.TransitionToState(Player.WalkingState);
        }
    }
}
