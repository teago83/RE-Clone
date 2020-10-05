using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingState : PlayerBaseState
{
    public override void EnterState(PlayerFSM Player)
    {
        
    }

    public override void OnCollisionEnter(PlayerFSM Player)
    {
        
    }

    public override void Update(PlayerFSM Player)
    {
        if (Input.GetMouseButtonDown(0)) {
            //if (Player.CurrentWeapon == 0)
            //{
            //    Player.Anime.Play("Firing Pistol");
            //}
            //else if (Player.CurrentWeapon == 1)
            //{
            //    Player.Anime.Play("Firing Shotgun");
            //}
            // Implement these conditions when you actually have the required animations.

            
            
        }
        else
        {
            Player.TransitionToState(Player.AimingState);
        }
    }
}
