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
    public int Health = 125;
    public bool HitByPlayer = false;
    public bool CanBeHit;
    // it begins as false, and becomes true if the player
    // has hit the zombie. when leaving the 'takingdamagestate',
    // this variable shall become false again
    public float TakingDamageCooldown;
    public float StartTakingDmgCooldown;

    public Transform[] MoveSpots;
    public int RandomSpot;

    private Rigidbody Rigidbody;

    // Player detection and attacking  
    public bool HaveISeenThePlayer;
    public bool InFrontOfPlayer;
    public GameObject ThePlayer;

    public Animator Anime;

    // Sound effects
    public AudioSource DyingSFX;
    public AudioSource Idle1SFX;
    public AudioSource FollowingSFX;
    public AudioSource AttackingSFX;
    public AudioSource TakingDamageSFX;

    public float IdleSFXCooldown = 20f;
    public float AttackingSFXCooldown = 9f;
    public float FollowingSFXCooldown = 25f;

    private void Start()
    {
        Anime = GetComponent<Animator>();
        TransitionToState(IdleState);
    }

    void Update()
    {
        CurrentZombieState.Update(this);
        // CanBeHit = makes it possible for the player to hit the zombie
        CanBeHit = true;
        Debug.Log(CurrentZombieState);
        Debug.Log("The zombie's current health is: " + Health);

        if (Health <= 0 && Health > -9999)
        {
            TransitionToState(DeadState);
        }
        if (TakingDamageCooldown > 0)
        {
            TakingDamageCooldown -= Time.deltaTime;
        }
        if ((CurrentZombieState == IdleState || CurrentZombieState == PatrolState) && IdleSFXCooldown <= 6f)
        {
            Debug.Log("Ihhh, alá, zumbizão barulhento");
            Idle1SFX.Play();
            IdleSFXCooldown = 20f;
        }

        else if (IdleSFXCooldown > 6f)
        {
            IdleSFXCooldown -= Time.deltaTime;
        }

        if (CurrentZombieState == CombatState && AttackingSFXCooldown <= 6f)
        {
            Debug.Log("Maluco, o zumbi quer me atacar, que horrorrrrrrr");
            AttackingSFX.Play();
            AttackingSFXCooldown = 9f;
        }

        else if (AttackingSFXCooldown > 6f)
        {
            AttackingSFXCooldown -= Time.deltaTime;
        }

        if (CurrentZombieState == FollowingState && FollowingSFXCooldown <= 6f)
        {
            Debug.Log("Esse zumbi não desiste mesmo -q");
            FollowingSFX.Play();
            FollowingSFXCooldown = 25f;
        }

        else if (FollowingSFXCooldown > 6f)
        {
            FollowingSFXCooldown -= Time.deltaTime;
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
