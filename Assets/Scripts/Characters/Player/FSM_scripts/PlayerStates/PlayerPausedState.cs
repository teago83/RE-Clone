using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPausedState : PlayerBaseState
{
    public override void EnterState(PlayerFSM Player)
    {

    }


    public override void OnCollisionEnter(PlayerFSM Player, Collision col)
    {


    }

    public override void Update(PlayerFSM Player)
    {

        if (Player.OnCutscene)
        {
            Player.animComp.SetBool("Running", false);
            Player.animComp.SetFloat("Velocity", 0f);
        }

        else if (!Player.OnCutscene)
        {
            Player.TransitionToState(PlayerFSM.LastPlayerState);
        }

        else if (!PlayerFSM.IsReading)
        {
            Player.TransitionToState(PlayerFSM.LastPlayerState);
        }
        else if (!PauseMenu.GamePaused)
        {
            Player.TransitionToState(PlayerFSM.LastPlayerState);
        }
        else if (!Inventory.InventoryOpen)
        {
            Player.TransitionToState(PlayerFSM.LastPlayerState);
        }
    }
}
