using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerFSM Player)
    {
        // These two bools are used to know if the player is being hit by
        // an attack or not. If they are, they'll transition to the 
        // "PlayerTakingDamageState".

        Player.AttackFromTheFront = false;
        Player.AttackFromTheBack = false;

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
