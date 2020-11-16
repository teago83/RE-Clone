using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimingState : PlayerBaseState
{

    public override void EnterState(PlayerFSM Player)
    {

        Player.animComp.SetBool("Aiming", true);

    }


    public override void OnCollisionEnter(PlayerFSM Player, Collision col)
    {

    }

    public override void Update(PlayerFSM Player)
    {

        if (Input.GetKey(KeyCode.Mouse0))
        {

            //fire
            if (Player.ShootingCooldown <= 0f)
            {
                if (Player.Weapons[PlayerFSM.CurrentWeapon].CurrentAmmo > 0)
                {
                    if (Physics.Raycast(Player.WeaponBullets[PlayerFSM.CurrentWeapon].transform.position, Player.WeaponBullets[PlayerFSM.CurrentWeapon].transform.forward, out Player.HitInfo, Player.Weapons[PlayerFSM.CurrentWeapon].ShootingRange))
                    {
                        ZombieAIFSM Zombie = Player.HitInfo.transform.GetComponent<ZombieAIFSM>();
                        if (Zombie != null)
                        {
                            if (PlayerFSM.CurrentWeapon == 1) { Zombie.health -= 35; }
                            else { Zombie.health -= 15; }
                        }
                    }
                    Player.Weapons[PlayerFSM.CurrentWeapon].CurrentAmmo -= 1;
                    Player.animComp.SetTrigger("Shoot");
                    Player.ShootingCooldown = Player.Weapons[PlayerFSM.CurrentWeapon].ShootingCooldown;

                    if (PlayerFSM.CurrentWeapon == 0)
                    {
                        Player.FiringPistolSFX.Play();
                        Player.PistolGunshot.Play();
                    }
                    else if (PlayerFSM.CurrentWeapon == 1)
                    {
                        Player.FiringShotgunSFX.Play();
                        Player.ShotgunGunshot.Play();
                    }
                    Debug.Log("Current " + Player.Weapons[PlayerFSM.CurrentWeapon].Name + " ammo: " + Player.Weapons[PlayerFSM.CurrentWeapon].CurrentAmmo);
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Player.TransitionToState(Player.IdleState);
        }

        Player.CanTurn();
    }
}