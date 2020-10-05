using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    public PlayerBaseState CurrentPlayerState;

    public readonly PlayerIdleState IdleState = new PlayerIdleState();
    public readonly PlayerAimingState AimingState = new PlayerAimingState();
    public readonly PlayerRunningState RunningState = new PlayerRunningState();
    public readonly PlayerWalkingState WalkingState = new PlayerWalkingState();
   
    public bool WalkingForward = false;
    public bool WalkingBack = false;
    public bool Rotating = false;
    public bool IsAiming = false;
    public float RotationalMovement;
    public float ForwardMovement;

    public Animator Anime;
    private Rigidbody Rigidbody;

    void Start()
    {
        Anime = GetComponent<Animator>();
        TransitionToState(IdleState);
    }

    void Update()
    {
        CurrentPlayerState.Update(this);
        Debug.Log(CurrentPlayerState);
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
}
