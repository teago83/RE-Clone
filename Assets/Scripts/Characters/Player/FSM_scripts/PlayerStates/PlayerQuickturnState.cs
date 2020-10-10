using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuickturnState : PlayerBaseState
{
    public override void EnterState(PlayerFSM Player)
    {
        Player.AlreadyQuickturned = false;
    }

    public override void OnCollisionEnter(PlayerFSM Player)
    {
        
    }

    public override void Update(PlayerFSM Player)
    {
        if (!Player.AlreadyQuickturned)
        {
            Player.Anime.Play("Quickturn");
            Player.QuickturnCooldown = .5f;
            Player.AlreadyQuickturned = true;
        }
        
        else if (Player.QuickturnCooldown >= 0)
        {
            Player.QuickturnCooldown -= Time.deltaTime;
        }

        else
        {
            Player.transform.Rotate(0, -180, 0);
            Player.TransitionToState(PlayerFSM.LastPlayerState);
        }

    }
}
