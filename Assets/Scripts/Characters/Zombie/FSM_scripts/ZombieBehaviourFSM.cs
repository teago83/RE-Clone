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

    public float StartWaitingTime;
    public float WaitingTime;
    public float Speed;

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
}
