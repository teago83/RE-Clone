using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerFSM Player)
    {

        Player.animComp.SetBool("Aiming", false);

    }


    public override void OnCollisionEnter(PlayerFSM Player, Collision col)
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
