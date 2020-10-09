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
            if (PlayerFSM.CurrentWeapon == 0 && Player.CurrentPistolAmmo > 0)
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
                Player.CurrentPistolAmmo -= 1;
                Player.Anime.Play("Firing Pistol");
                Player.FiringPistolSFX.Play();
                Player.PistolGunshot.Play();
                Player.ShootingCooldown = 1.2f;
                Player.ShootingAnimationCooldown = .5f;
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
                Player.ShootingCooldown = 1.5f;
                Player.ShootingAnimationCooldown = .5f;
            }
        }
        if (Player.ShootingAnimationCooldown > 0f)
        {
            Player.ShootingAnimationCooldown -= Time.deltaTime;
        }
        else
        {
            Player.TransitionToState(Player.AimingState);
        }
    }
}
