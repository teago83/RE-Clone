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

        Player.CanTurn();

    }
}
