using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour_FSM : MonoBehaviour
{
    public ZombieBaseState CurrentZombieState;

    public readonly ZombieIdleState IdleState = new ZombieIdleState();
    public readonly ZombiePatrolState PatrolState = new ZombiePatrolState();
    public readonly ZombieCombatState CombatState = new ZombieCombatState();

    public readonly float StartWaitingTime = 5f;
    public float WaitingTime;
    public readonly float Speed = 2f;
    //public readonly float TurnSpeed = 180;

    public Transform[] MoveSpots;
    public int RandomSpot;

    private Rigidbody Rigidbody;

    //any states that require the usage of the zombie's rigidbody or currentstate can just reference these getters
    public Rigidbody Rb
    {
        get { return Rigidbody; }
    }

    //public ZombieBaseState CurrentState
    //{
    //    get { return CurrentState; }
    //}

    private void Awake()
    {

    }

    private void Start()
    {
        TransitionToState(IdleState);
    }

    void Update()
    {
        CurrentZombieState.Update(this);
        Debug.Log(CurrentZombieState);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CurrentZombieState.OnCollisionEnter(this);
    }

    public void TransitionToState(ZombieBaseState State)
    {
        CurrentZombieState = State;
        CurrentZombieState.EnterState(this);
    }

}
