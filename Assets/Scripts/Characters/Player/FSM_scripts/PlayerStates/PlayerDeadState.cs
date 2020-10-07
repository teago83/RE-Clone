using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    public override void EnterState(PlayerFSM Player)
    {
        Player.Anime.Play("Death");
    }
    public override void OnCollisionEnter(PlayerFSM Player)
    {
        
    }
    public override void Update(PlayerFSM Player)
    {
        
    }
}