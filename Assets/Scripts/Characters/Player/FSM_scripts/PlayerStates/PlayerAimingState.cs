using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimingState : PlayerBaseState
{

    public override void EnterState(PlayerFSM Player)
    {

    }

    public override void OnCollisionEnter(PlayerFSM Player)
    {
        
    }

    public override void Update(PlayerFSM Player)
    {
        PlayerFSM.CurrentWeaponDamage = Player.Weapons[PlayerFSM.CurrentWeapon].Damage;
        if (Input.GetMouseButton(1))
        {
            Player.EquippedWeapon[PlayerFSM.CurrentWeapon].SetActive(true);
            Player.Anime.Play(Player.Weapons[PlayerFSM.CurrentWeapon].AimingAnimation);
            
            // the player rotates while they're aiming
            if (Input.GetButton("Horizontal"))
            {
                Player.RotationalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * 120f;
                Player.transform.Rotate(0, Player.RotationalMovement, 0);
            }
            // or, the player shoots (if they have ammo)
            else if (Input.GetMouseButtonDown(0) && Player.ShootingCooldown <= 0)
            {
                Player.TransitionToState(Player.ShootingState);
            }

            if (Player.AttackFromTheFront == true || Player.AttackFromTheBack == true)
            {
                Player.EquippedWeapon[PlayerFSM.CurrentWeapon].SetActive(false);
                Player.TransitionToState(Player.TakingDamageState);
            }
        }
        else
        {
            //Deactivates the current weapon
            Player.EquippedWeapon[PlayerFSM.CurrentWeapon].SetActive(false);
            Player.TransitionToState(Player.IdleState);
        }

        if (Player.AttackFromTheFront == true || Player.AttackFromTheBack == true)
        {
            Player.EquippedWeapon[PlayerFSM.CurrentWeapon].SetActive(false);
            Player.TransitionToState(Player.TakingDamageState);
        }
        
    }
}