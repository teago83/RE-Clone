using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingState : PlayerBaseState
{
    public override void EnterState(PlayerFSM Player)
    {
        
    }

    public override void OnCollisionEnter(PlayerFSM Player)
    {
        
    }

    public override void Update(PlayerFSM Player)
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

            Player.ForwardMovement = Input.GetAxis("Vertical") * Time.deltaTime * 7f;
            Player.RotationalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * 130f;
            Player.transform.Translate(0, 0, Player.ForwardMovement);
            Player.transform.Rotate(0, Player.RotationalMovement, 0);
        }
        
        else
        {
            Player.TransitionToState(Player.IdleState);
        }

        if (Input.GetMouseButton(1))
        {
            Player.TransitionToState(Player.AimingState);
        }

        if (Player.AttackFromTheFront == true || Player.AttackFromTheBack == true)
        {
            Player.TransitionToState(Player.TakingDamageState);
        }

        // Equips the pistol
        if (Input.GetKey(KeyCode.Keypad1))
        {
            PlayerFSM.CurrentWeapon = 0;
        }
        //Equips the shotgun
        else if (Input.GetKey(KeyCode.Keypad2))
        {
            PlayerFSM.CurrentWeapon = 1;
        }
    }
}
