using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimingState : PlayerBaseState
{

    public override void EnterState(PlayerFSM Player)
    {

        Player.animComp.SetBool("Aiming", true);

    }


    public override void OnCollisionEnter(PlayerFSM Player)
    {

    }

    public override void Update(PlayerFSM Player)
    {
<<<<<<< Updated upstream
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
                Player.TransitionToState(Player.ShootingState);
            }
=======

        if (Input.GetKey(KeyCode.Mouse0))
        {
>>>>>>> Stashed changes

            //fire
            if (Player.ShootingCooldown <= 0f)
            {
<<<<<<< Updated upstream
                Player.Weapons[PlayerFSM.CurrentWeapon].SetActive(false);
                Player.TransitionToState(Player.TakingDamageState);
=======
                if (Player.Weapons[PlayerFSM.CurrentWeapon].CurrentAmmo > 0)
                {
                    if (Physics.Raycast(Player.WeaponBullets[PlayerFSM.CurrentWeapon].transform.position, Player.WeaponBullets[PlayerFSM.CurrentWeapon].transform.forward, out Player.HitInfo, Player.Weapons[PlayerFSM.CurrentWeapon].ShootingRange))
                    {
                        Debug.Log(Player.HitInfo.transform.name);
                        ZombieBehaviourFSM Zombie = Player.HitInfo.transform.GetComponent<ZombieBehaviourFSM>();
                        if (Zombie != null)
                        {
                            Zombie.ReallyHitByPlayer();
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
>>>>>>> Stashed changes
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
<<<<<<< Updated upstream
            //Deactivates the current weapon
            Player.Weapons[PlayerFSM.CurrentWeapon].SetActive(false);
=======
>>>>>>> Stashed changes
            Player.TransitionToState(Player.IdleState);
            Player.animComp.SetBool("Aiming", false);
        }

<<<<<<< Updated upstream
        if (Player.AttackFromTheFront == true || Player.AttackFromTheBack == true)
        {
            Player.Weapons[PlayerFSM.CurrentWeapon].SetActive(false);
            Player.TransitionToState(Player.TakingDamageState);
        }
        
=======
        Player.CanTurn();
>>>>>>> Stashed changes
    }
}

/*if (PlayerFSM.CurrentWeapon == 0 && Player.CurrentPistolAmmo > 0)
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
                    Player.Anime.Play("Firing Pistol");
                    Player.FiringPistolSFX.Play();
                    Player.PistolGunshot.Play();
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
                    Player.Anime.Play("Firing Shotgun");
                    Player.FiringShotgunSFX.Play();
                    Player.ShotgunGunshot.Play();
                    Player.ShootingCooldown = 2f;
                }*/