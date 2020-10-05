using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimingState : PlayerBaseState
{
    public override void EnterState(PlayerFSM Player)
    {
        // Activates the current weapon
        Player.Weapons[Player.CurrentWeapon].SetActive(true);
    }

    public override void OnCollisionEnter(PlayerFSM Player)
    {
        
    }

    public override void Update(PlayerFSM Player)
    {
        if (Input.GetMouseButton(1))
        {
            if (Input.GetButton("Horizontal"))
            {
                Player.RotationalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * 120f;
                Player.transform.Rotate(0, Player.RotationalMovement, 0);
            }

            // The player will only be able to shoot if they're aiming, duh
            if (Input.GetMouseButtonDown(0))
            {
                
                Debug.Log("Hey man, nice shot");
            }

            if (Player.CurrentWeapon == 0)
            {
                Player.Anime.Play("Aiming SniperRifle");
            }
            if (Player.CurrentWeapon == 1)
            {
                Player.Anime.Play("Aiming Pistol");
            }
        }
        else
        {
            //Deactivates the current weapon
            Player.Weapons[Player.CurrentWeapon].SetActive(false);
            Player.TransitionToState(Player.IdleState);
        }
    }
}
