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

        Player.CanTurn();
        Player.CanWalk();

    }
}
