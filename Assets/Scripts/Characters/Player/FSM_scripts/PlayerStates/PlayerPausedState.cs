using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPausedState : PlayerBaseState
{
    public override void EnterState(PlayerFSM Player)
    {

    }

    public override void OnCollisionEnter(PlayerFSM Player)
    {
        
    }

    public override void Update(PlayerFSM Player)
    {
        if (PlayerFSM.IsReading == false)
        {
            Player.TransitionToState(Player.IdleState);
        }
    }
}
