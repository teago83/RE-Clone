using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimingState : PlayerBaseState
{

    public override void EnterState(PlayerFSM Player)
    {
        // Activates the current weapon
        Player.Weapons[PlayerFSM.CurrentWeapon].SetActive(true);
    }

    public override void OnCollisionEnter(PlayerFSM Player)
    {
        
    }

    public override void Update(PlayerFSM Player)
    {
        if (Input.GetMouseButton(1))
        {
            if (PlayerFSM.CurrentWeapon == 0)
            {
                Player.Anime.Play("Aiming Pistol");
            }
            else if (PlayerFSM.CurrentWeapon == 1)
            {
                Player.Anime.Play("Aiming Shotgun");
            }
            // the player rotates while they're aiming
            if (Input.GetButton("Horizontal"))
            {
                Player.RotationalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * 120f;
                Player.transform.Rotate(0, Player.RotationalMovement, 0);
            }
            // or, the player shoots (if they have ammo)
            else if (Input.GetMouseButtonDown(0) && Player.ShootingCooldown <= 0)
            {
                if (PlayerFSM.CurrentWeapon == 0 && Player.CurrentPistolAmmo > 0)
                {
                    if (Physics.Raycast(Player.WeaponBullets[0].transform.position, Player.WeaponBullets[0].transform.forward, out Player.HitInfo, Player.PistolShootingRange)){
                        Debug.Log(Player.HitInfo.transform.name);
                        ZombieBehaviourFSM Zombie = Player.HitInfo.transform.GetComponent<ZombieBehaviourFSM>();
                        if (Zombie != null)
                        {
                            Zombie.ReallyHitByPlayer();
                        }
                    }
                    Player.CurrentPistolAmmo -= 1;
                    Player.FiringPistolSFX.Play();
                    Player.ShootingCooldown = 1.8f;
                }
                else if (PlayerFSM.CurrentWeapon == 1 && Player.CurrentShotgunAmmo > 0)
                {
                    if (Physics.Raycast(Player.WeaponBullets[1].transform.position, Player.WeaponBullets[1].transform.forward, out Player.HitInfo, Player.ShotgunShootingRange))
                    {
                        Debug.Log(Player.HitInfo.transform.name);
                        ZombieBehaviourFSM Zombie = Player.HitInfo.transform.GetComponent<ZombieBehaviourFSM>();
                        if (Zombie != null)
                        {
                            Zombie.ReallyHitByPlayer();
                        }
                    }
                    Player.CurrentShotgunAmmo -= 1;
                    Player.FiringShotgunSFX.Play();
                    Player.ShootingCooldown = 2f;
                }
            }

            else if (Player.ShootingCooldown > 0)
            {
                Player.ShootingCooldown -= Time.deltaTime;
            }

            if (Player.AttackFromTheFront == true || Player.AttackFromTheBack == true)
            {
                Player.Weapons[PlayerFSM.CurrentWeapon].SetActive(false);
                Player.TransitionToState(Player.TakingDamageState);
            }
        }
        else
        {
            //Deactivates the current weapon
            Player.Weapons[PlayerFSM.CurrentWeapon].SetActive(false);
            Player.TransitionToState(Player.IdleState);
        }

        if (Player.AttackFromTheFront == true || Player.AttackFromTheBack == true)
        {
            Player.Weapons[PlayerFSM.CurrentWeapon].SetActive(false);
            Player.TransitionToState(Player.TakingDamageState);
        }
    }
}
