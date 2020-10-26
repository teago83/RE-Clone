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
        if (Player.ShootingCooldown <= 0f)
        {
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
                Player.Anime.Play(Player.Weapons[PlayerFSM.CurrentWeapon].FiringAnimation);
                Player.ShootingCooldown = Player.Weapons[PlayerFSM.CurrentWeapon].ShootingCooldown;
                Player.FiringAnimationCooldown = Player.Weapons[PlayerFSM.CurrentWeapon].FiringAnimationCooldown;

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
        if (Player.FiringAnimationCooldown > 0f)
        {
            Player.FiringAnimationCooldown -= Time.deltaTime;
        }
        else
        {
            Player.TransitionToState(Player.AimingState);
        }
    }
}
