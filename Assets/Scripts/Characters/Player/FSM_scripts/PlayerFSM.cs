﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    public PlayerBaseState CurrentPlayerState;

    public readonly PlayerIdleState IdleState = new PlayerIdleState();
    public readonly PlayerAimingState AimingState = new PlayerAimingState();
    public readonly PlayerRunningState RunningState = new PlayerRunningState();
    public readonly PlayerWalkingState WalkingState = new PlayerWalkingState();
    public readonly PlayerDeadState DeadState = new PlayerDeadState();
   
    // Movement-related variables
    public bool WalkingForward = false;
    public bool WalkingBack = false;
    public bool Rotating = false;
    public bool IsAiming = false;
    public float RotationalMovement;
    public float ForwardMovement;

    public Animator Anime;
    private Rigidbody Rigidbody;

    // Health-related stuff
    public int MaxHealth;
    public int Health;
    public bool AttackFromTheFront;
    public bool AttackFromTheBack;
    public int TakingDamageWaitTime;

    void Start()
    {
        MaxHealth = 5;
        Health = MaxHealth;
        Anime = GetComponent<Animator>();
        TransitionToState(IdleState);
    }

    void Update()
    {
        CurrentPlayerState.Update(this);
        Debug.Log(CurrentPlayerState);

        if (Health <= 0)
        {
            TransitionToState(DeadState);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        CurrentPlayerState.OnCollisionEnter(this);
    }

    public void TransitionToState(PlayerBaseState State)
    {
        CurrentPlayerState = State;
        CurrentPlayerState.EnterState(this);
    }

    /* If the zombie's hand comes in contact with the player, 
     * the player's health will be decreased. */

    public void AttackCameFromTheFront()
    {
        AttackFromTheBack = false;
        AttackFromTheFront = true;
    }
    public void AttackCameFromTheBack()
    {
        AttackFromTheBack = true;
        AttackFromTheFront = false;
    }
}
