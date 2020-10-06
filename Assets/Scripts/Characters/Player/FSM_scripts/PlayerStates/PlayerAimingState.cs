using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimingState : PlayerBaseState
{
    Vector3 StartingPistolBulletPosition;

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
            if (Player.CurrentWeapon == 0)
            {
                Player.Anime.Play("Aiming Pistol");
            }
            else if (Player.CurrentWeapon == 1)
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
            else if (Input.GetMouseButtonDown(0))
            {
                if (Player.CurrentWeapon == 0 && Player.CurrentPistolAmmo > 0)
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
                }
                else if (Player.CurrentWeapon == 1 && Player.CurrentShotgunAmmo > 0)
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
                }
            }

            if (Player.AttackFromTheFront == true || Player.AttackFromTheBack == true)
            {
                Player.Weapons[Player.CurrentWeapon].SetActive(false);
                Player.TransitionToState(Player.TakingDamageState);
            }
        }
        else
        {
            //Deactivates the current weapon
            Player.Weapons[Player.CurrentWeapon].SetActive(false);
            Player.TransitionToState(Player.IdleState);
        }

        if (Player.AttackFromTheFront == true || Player.AttackFromTheBack == true)
        {
            Player.Weapons[Player.CurrentWeapon].SetActive(false);
            Player.TransitionToState(Player.TakingDamageState);
        }
    }
}
