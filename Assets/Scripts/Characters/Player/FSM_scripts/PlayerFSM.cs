using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayerFSM : MonoBehaviour
{
    // States
    public readonly PlayerIdleState IdleState = new PlayerIdleState();
    public readonly PlayerAimingState AimingState = new PlayerAimingState();
    public readonly PlayerRunningState RunningState = new PlayerRunningState();
    public readonly PlayerWalkingState WalkingState = new PlayerWalkingState();
    public readonly PlayerTakingDamageState TakingDamageState = new PlayerTakingDamageState();
    public readonly PlayerPausedState PausedState = new PlayerPausedState();
    public readonly PlayerDeadState DeadState = new PlayerDeadState();
    public readonly PlayerShootingState ShootingState = new PlayerShootingState();
    public readonly PlayerQuickturnState QuickturnState = new PlayerQuickturnState();

    public PlayerBaseState CurrentPlayerState;
    public static PlayerBaseState LastPlayerState; // Used so that the player doesn't go from, for example,
                                                   // the aiming state, onto the PausedState, and then back
                                                   // to the IdleState, making the weapon they were aiming
                                                   // still visible

    [Space]
    [Header("Player velocity stats")]

    // Movement 
    public bool WalkingForward = false;
    public bool WalkingBack = false;
    public float RotationalMovement;
    public float ForwardMovement;
    public Animator Anime;
    public static Vector3 CurrentPosition; // Made so that other objects can reference the player's current position,
                                           // mainly the zombie.

    // Health and damage
    public static int MaxHealth;
    public static int Health;
    public bool AttackFromTheFront;
    public bool AttackFromTheBack;
    public float TakingDamageWaitTime;
    public float DamageCooldown;

    // The player's weaponry

    // Quick note on static variables:
    // A static variable can be referenced by other scripts

    public Weapon[] Weapons;
    public GameObject[] EquippedWeapon;
    public ParticleSystem PistolGunshot;
    public ParticleSystem ShotgunGunshot;

    // The weapon object is used to get the important values regarding the current weapon,
    // while the GameObject is used to activate/deactivate the currently equipped weapon's
    // model while the player is (or isn't) using such weapon. 

    public static int CurrentWeapon;
    // WeaponBullets = used as reference for the Raycast to know where the shots will be fired from
    public GameObject[] WeaponBullets;
    // HitInfo displays some info on what the weapon's bullet has shot
    public RaycastHit HitInfo;
    public float ShootingCooldown;
    public static int CurrentWeaponDamage; // Used to make it easier to reference the player's
                                           // current damage to the zombie if the zombie gets hit

    // Sound Effects
    public AudioSource FiringPistolSFX;
    public AudioSource FiringShotgunSFX;
    public AudioSource DyingSFX;
    public AudioSource PlayerTakingDamageSFX;

    // Interaction 
    public static bool IsReading;

    // Item count
    public static int MiniKeyCount;

    // Animation Stuff
    public float FiringAnimationCooldown;
    public float QuickturnCooldown;
    public bool AlreadyQuickturned;

    void Start()
    {
        MaxHealth = 125;
        Health = MaxHealth;
        Anime = GetComponent<Animator>();
        TransitionToState(IdleState);

        for (int i = 0; i < Weapons.Length; i++)
        {
            Weapons[i].CurrentAmmo = Weapons[i].MaxAmmo;
        }
    }

    void Update()
    {
        CurrentPlayerState.Update(this);
        CurrentPosition = transform.position;

        if (Health <= 0 && Health > -9999)
        {
            TransitionToState(DeadState);
        }

        /* These if statements are here so that their respective cooldown variables
         * are always being decreased if they're bigger than 0. It didn't work
         * as intended if they were put into the states themselves. */

        if (DamageCooldown > 0)
        {
            DamageCooldown -= Time.deltaTime;
        }
        if (ShootingCooldown > 0)
        {
            ShootingCooldown -= Time.deltaTime;
        }

        if (IsReading || PauseMenu.GamePaused || Inventory.InventoryOpen)
        {
            LastPlayerState = CurrentPlayerState;
            TransitionToState(PausedState);
        }

        if (Health > MaxHealth)
            Health = MaxHealth;

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
