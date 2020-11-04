using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingState : PlayerBaseState
{
    public override void EnterState(PlayerFSM Player)
    {


    }

    public override void OnCollisionEnter(PlayerFSM Player)
    {

    }

    public override void Update(PlayerFSM Player)
    {


        if (Player.fowardAxis == 0)
        {

            Player.TransitionToState(Player.IdleState);

        }

<<<<<<< Updated upstream
        if (Player.AttackFromTheFront == true || Player.AttackFromTheBack == true)
        {
            Player.TransitionToState(Player.TakingDamageState);
        }

        // Equips the pistol
        if (Input.GetKey(KeyCode.Keypad1))
        {
            PlayerFSM.CurrentWeapon = 0;
        }
        //Equips the shotgun
        else if (Input.GetKey(KeyCode.Keypad2))
        {
            PlayerFSM.CurrentWeapon = 1;
        }
=======
        Player.CanTurn();
        Player.CanWalk();

>>>>>>> Stashed changes
    }
}
