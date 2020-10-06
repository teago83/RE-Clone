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
            //Player.Gunshot.Play();

            // Zombie.transform.position = Vector3.MoveTowards(Zombie.transform.position, Zombie.MoveSpots[Zombie.RandomSpot].position, Zombie.Speed * Time.deltaTime); 

            // Player.PistolBullet.transform.Translate(10, 10, 10);
            Debug.Log("Hey, stop shooting, punk");

        }
        else
        {

            //Player.Gunshot.Pause();
            Player.TransitionToState(Player.AimingState);
        }
    }
}
