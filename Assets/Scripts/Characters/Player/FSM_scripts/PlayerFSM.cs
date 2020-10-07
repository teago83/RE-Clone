﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    // States
    public PlayerBaseState CurrentPlayerState;
    public readonly PlayerIdleState IdleState = new PlayerIdleState();
    public readonly PlayerAimingState AimingState = new PlayerAimingState();
    public readonly PlayerRunningState RunningState = new PlayerRunningState();
    public readonly PlayerWalkingState WalkingState = new PlayerWalkingState();
    public readonly PlayerTakingDamageState TakingDamageState = new PlayerTakingDamageState();
    public readonly PlayerDeadState DeadState = new PlayerDeadState();
   
    // Movement 
    public bool WalkingForward = false;
    public bool WalkingBack = false;
    public float RotationalMovement;
    public float ForwardMovement;
    public Animator Anime;

    // Health and damage
    public int MaxHealth;
    public int Health;
    public bool AttackFromTheFront;
    public bool AttackFromTheBack;
    public float TakingDamageWaitTime;
    public float DamageCooldown;

    // The player's weaponry

    // Quick note on static variables:
    // A static variable can be referenced by another script
    
    // Pistol
    public static int PistolDamage = 20;
    public int MaxPistolAmmo = 15;
    public int CurrentPistolAmmo;
    public float PistolShootingRange = 40f;
    public ParticleSystem Gunshot;
    // Shotgun
    public static int ShotgunDamage = 60;
    public int MaxShotgunAmmo = 8;
    public int CurrentShotgunAmmo;
    public float ShotgunShootingRange = 15f;
    
    public GameObject[] Weapons;
    public int CurrentWeapon;
    // WeaponBullets = used as reference for the Raycast to know where the shots will be fired from
    public GameObject[] WeaponBullets;
    // HitInfo displays some info on what the weapon's bullet has shot
    public RaycastHit HitInfo;
    public float ShootingCooldown;

    // Sound Effects
    public AudioSource FiringPistolSFX;
    public AudioSource FiringShotgunSFX;
    public AudioSource DyingSFX;
    public AudioSource PlayerTakingDamageSFX;

    // Testing variables

    void Start()
    {
        MaxHealth = 125;
        Health = MaxHealth;
        Anime = GetComponent<Animator>();
        CurrentPistolAmmo = MaxPistolAmmo;
        CurrentShotgunAmmo = MaxShotgunAmmo;
        TransitionToState(IdleState);
    }

    void Update()
    {
        CurrentPlayerState.Update(this);
        Debug.Log(CurrentPlayerState);

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
