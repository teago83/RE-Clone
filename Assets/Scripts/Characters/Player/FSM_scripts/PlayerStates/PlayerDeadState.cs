using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    public override void EnterState(PlayerFSM Player)
    {
        PlayerFSM.Health = -999999999;

        /* Such a high (or, in this case, low) number was applied to the
         * player's health to prevent the FSM's update method to keep on calling
         * the DeadState like it calls the other ones. This way, the player shall
         * enter this state only once, making it possible for the Dying sound effect
         * to be played correctly. */

        Player.animComp.Play("Death");
        Player.DyingSFX.Play();

    }


    public override void OnCollisionEnter(PlayerFSM Player)
    {

    }
    public override void Update(PlayerFSM Player)
    {

    }
}