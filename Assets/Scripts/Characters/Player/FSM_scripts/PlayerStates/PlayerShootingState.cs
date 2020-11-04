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
<<<<<<< Updated upstream
        if (Player.ShootingCooldown <= 0f)
        {
            if (PlayerFSM.CurrentWeapon == 0 && PlayerFSM.CurrentPistolAmmo > 0)
            {
                if (Physics.Raycast(Player.WeaponBullets[0].transform.position, Player.WeaponBullets[0].transform.forward, out Player.HitInfo, Player.PistolShootingRange))
                {
                    Debug.Log(Player.HitInfo.transform.name);
                    ZombieBehaviourFSM Zombie = Player.HitInfo.transform.GetComponent<ZombieBehaviourFSM>();
                    if (Zombie != null)
                    {
                        Zombie.ReallyHitByPlayer();
                    }
                }
                PlayerFSM.CurrentPistolAmmo -= 1;
                Player.Anime.Play("Firing Pistol");
                Player.FiringPistolSFX.Play();
                Player.PistolGunshot.Play();
                Player.ShootingCooldown = 1.2f;
                Player.ShootingAnimationCooldown = .5f;
            }
            else if (PlayerFSM.CurrentWeapon == 1 && PlayerFSM.CurrentShotgunAmmo > 0)
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
                PlayerFSM.CurrentShotgunAmmo -= 1;
                Player.Anime.Play("Firing Shotgun");
                Player.FiringShotgunSFX.Play();
                Player.ShotgunGunshot.Play();
                Player.ShootingCooldown = 1.5f;
                Player.ShootingAnimationCooldown = .5f;
            }
        }
        if (Player.ShootingAnimationCooldown > 0f)
=======
        //if (Player.ShootingCooldown <= 0f)
        //{
        //    if (Player.Weapons[PlayerFSM.CurrentWeapon].CurrentAmmo > 0)
        //    {
        //        if (Physics.Raycast(Player.WeaponBullets[PlayerFSM.CurrentWeapon].transform.position, Player.WeaponBullets[PlayerFSM.CurrentWeapon].transform.forward, out Player.HitInfo, Player.Weapons[PlayerFSM.CurrentWeapon].ShootingRange))
        //        {
        //            Debug.Log(Player.HitInfo.transform.name);
        //            ZombieBehaviourFSM Zombie = Player.HitInfo.transform.GetComponent<ZombieBehaviourFSM>();
        //            if (Zombie != null)
        //            {
        //                Zombie.ReallyHitByPlayer();
        //            }
        //        }
        //        Player.Weapons[PlayerFSM.CurrentWeapon].CurrentAmmo -= 1;
        //        Player.animComp.Play(Player.Weapons[PlayerFSM.CurrentWeapon].FiringAnimation);
        //        Player.ShootingCooldown = Player.Weapons[PlayerFSM.CurrentWeapon].ShootingCooldown;
        //        Player.FiringAnimationCooldown = Player.Weapons[PlayerFSM.CurrentWeapon].FiringAnimationCooldown;

        //        if (PlayerFSM.CurrentWeapon == 0) 
        //        {
        //            Player.FiringPistolSFX.Play();
        //            Player.PistolGunshot.Play();
        //        }
        //        else if (PlayerFSM.CurrentWeapon == 1)
        //        {
        //            Player.FiringShotgunSFX.Play();
        //            Player.ShotgunGunshot.Play();
        //        }
        //        Debug.Log("Current " + Player.Weapons[PlayerFSM.CurrentWeapon].Name + " ammo: " + Player.Weapons[PlayerFSM.CurrentWeapon].CurrentAmmo);
        //    }
        //}
        if (Player.FiringAnimationCooldown > 0f)
>>>>>>> Stashed changes
        {
            Player.ShootingAnimationCooldown -= Time.deltaTime;
        }
        else
        {
            Player.TransitionToState(Player.AimingState);
        }
    }
}
