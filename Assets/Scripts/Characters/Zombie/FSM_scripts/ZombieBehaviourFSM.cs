using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviourFSM : MonoBehaviour
{
    public ZombieBaseState CurrentZombieState;

    public readonly ZombieIdleState IdleState = new ZombieIdleState();
    public readonly ZombiePatrolState PatrolState = new ZombiePatrolState();
    public readonly ZombieFollowingState FollowingState = new ZombieFollowingState();
    public readonly ZombieCombatState CombatState = new ZombieCombatState();
    /* NoPoint = When the player is dead and the zombie has nothing to do.
       I didn't just use the IdleState because the zombie would be able to
       transit to other states and this would cause some issues due to the
       dead player object on the ground.*/
    public readonly ZombieNoPointState NoPointState = new ZombieNoPointState();
    public readonly ZombieTakingDamageState TakingDamageState = new ZombieTakingDamageState();
    public readonly ZombieDeadState DeadState = new ZombieDeadState();

    public float StartWaitingTime = 5;
    public float WaitingTime;
    public float Speed = 2.6f;

    // Health
    public int Health = 150;
    public bool HitByPlayer = false;
    // it begins as false, and becomes true if the player
    // has hit the zombie. when leaving the 'takingdamagestate',
    // this variable shall become false again
    public float TakingDamageWaitTime;

    public Transform[] MoveSpots;
    public int RandomSpot;

    private Rigidbody Rigidbody;

    // stuff related to detecting and attacking the player 
    public bool HaveISeenThePlayer;
    public bool InFrontOfPlayer;
    public GameObject ThePlayer;

    public Animator Anime;

    private void Start()
    {
        Anime = GetComponent<Animator>();
        TransitionToState(IdleState);
    }

    void Update()
    {
        CurrentZombieState.Update(this);
        Debug.Log(CurrentZombieState);

        if (Health <= 0)
        {
            TransitionToState(DeadState);
        }
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

    // Used to enable the zombie to follow the player around
    public void SeenThePlayer()
    {
        HaveISeenThePlayer = true;        
    }
    public void NotSeenThePlayer()
    {
        HaveISeenThePlayer = false;
    }

    // Used to enable the zombie to attack the player
    public void ReallyInFrontOfPlayer()
    {
        InFrontOfPlayer = true;
    }
    public void NotInFrontOfPlayer()
    {
        InFrontOfPlayer = false;
    }
    public void ReallyHitByPlayer()
    {
        HitByPlayer = true;
    }
}
