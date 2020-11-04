using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerFSM Player)
    {
        // These two bools are used to know if the player is being hit by
        // an attack or not. If they are, they'll transition to the 
        // "PlayerTakingDamageState".

        Player.AttackFromTheFront = false;
        Player.AttackFromTheBack = false;

    }


    public override void OnCollisionEnter(PlayerFSM Player)
    {

    }

    public override void Update(PlayerFSM Player)
    {

        if (Player.fowardAxis != 0)
        {
            Player.TransitionToState(Player.WalkingState);
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.S))
        {
            Player.animComp.SetTrigger("Quickturn");
            Player.canReceiveInput = false;
            PlayerFSM.LastPlayerState = Player.IdleState;

        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {

            Player.TransitionToState(Player.AimingState);

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

>>>>>>> Stashed changes
    }
}
