using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(Rigidbody))]
public class PlayerFSM : MonoBehaviour
{



    #region States
    public readonly PlayerIdleState IdleState = new PlayerIdleState();
    public readonly PlayerAimingState AimingState = new PlayerAimingState();
    public readonly PlayerWalkingState WalkingState = new PlayerWalkingState();
    public readonly PlayerPausedState PausedState = new PlayerPausedState();
    public readonly PlayerDeadState DeadState = new PlayerDeadState();
    public readonly PlayerShootingState ShootingState = new PlayerShootingState();

    public PlayerBaseState CurrentPlayerState;
    public static PlayerBaseState LastPlayerState; // Used so that the player doesn't go from, for example,
                                                   // the aiming state, onto the PausedState, and then back
                                                   // to the IdleState, making the weapon they were aiming
                                                   // still visible

    #endregion

    [Space]
    [Header("Player velocity stats")]


    #region Movement

    [HideInInspector]
    public float fowardAxis;
    [HideInInspector]
    public bool canReceiveInput;
    [HideInInspector]
    public float turnAxis;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float backwardSpeed;
    [SerializeField]
    private float runningSpeed;
    [SerializeField]
    private float turnSpeed;

    public Animator animComp;
    public static Vector3 CurrentPosition; // Made so that other objects can reference the player's current position,

    #endregion                                       // mainly the zombie.

    // Health and damage
    //public static int MaxHealth;
    public static int Health = 100;

    // The player's weaponry

    // Quick note on static variables:
    // A static variable can be referenced by other scripts

    public Weapon[] Weapons;
    public GameObject[] EquippedWeapon;
    public GameObject PistolGunshot;
    public GameObject ShotgunGunshot;
    private Rigidbody rBody;
    public Vector3 posBeforeHit;

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
    public static bool isAlive = true;

    // Item count
    public static int MiniKeyCount;

    // Animation Stuff
    public float FiringAnimationCooldown;
    public float QuickturnCooldown;



    void Start()
    {

        ZombieState_Biting.Bite += TakeDamageFromZombie;
        canReceiveInput = true; //Just for garantir

        Health = 100;
        isAlive = true;
        //Health = MaxHealth;
        animComp = GetComponent<Animator>();
        TransitionToState(IdleState);

        for (int i = 0; i < Weapons.Length; i++)
        {
            Weapons[i].CurrentAmmo = Weapons[i].MaxAmmo;
        }

        rBody = GetComponent<Rigidbody>();


    }


    void Update()
    {
        CurrentPlayerState.Update(this);
        CurrentPosition = transform.position;

        /* These if statements are here so that their respective cooldown variables
         * are always being decreased if they're bigger than 0. It didn't work
         * as intended if they were put into the states themselves. */

        if (ShootingCooldown > 0)
        {
            ShootingCooldown -= Time.deltaTime;
        }

        if (IsReading || PauseMenu.GamePaused || Inventory.InventoryOpen)
        {
            LastPlayerState = CurrentPlayerState;
            TransitionToState(PausedState);
        }

        Debug.Log(Health);

        //if (Health > MaxHealth)
        //    Health = MaxHealth;

        if (Health <= 0)
        {

            isAlive = false;
            animComp.SetBool("IsDead", true);
            rBody.freezeRotation = true;

        }

        animComp.SetInteger("EquippedGun", CurrentWeapon);

        if (CurrentWeapon == 0)
        {

            EquippedWeapon[0].SetActive(true);
            EquippedWeapon[1].SetActive(false);

        }
        else
        {

            EquippedWeapon[0].SetActive(false);
            EquippedWeapon[1].SetActive(true);


        }

        if (canReceiveInput)
        {
            fowardAxis = Input.GetAxisRaw("Vertical");
            turnAxis = Input.GetAxisRaw("Horizontal");

        }
    }



    private void OnCollisionEnter(Collision collision)
    {

        #region ZombieCode
        //if (collision.collider.CompareTag("Zombie"))
        //{
        //    if (collision.collider.GetComponent<ZombieAIFSM>().isAttacking == true) { }
        //} 
        #endregion

        CurrentPlayerState.OnCollisionEnter(this, collision);

    }

    public void TransitionToState(PlayerBaseState State)
    {
        CurrentPlayerState = State;
        CurrentPlayerState.EnterState(this);
    }

    public void Quickturn()
    {

        transform.Rotate(0, -180, 0);
        TransitionToState(IdleState);
        canReceiveInput = true;
    }
    public void CanWalk()
    {


        bool running = (Input.GetKey(KeyCode.LeftShift) ? true : false);

        float fowardSpeed = (running) ? runningSpeed : speed;
        float velocity = (fowardAxis < 0) ? backwardSpeed : fowardSpeed;

        animComp.SetFloat("Velocity", fowardAxis);
        animComp.SetBool("Running", running);
        rBody.transform.Translate(Vector3.forward * fowardAxis * velocity * Time.deltaTime);

    }
    public void CanTurn()
    {

        rBody.transform.Rotate(Vector3.up * turnAxis * turnSpeed * Time.deltaTime);

    }
    public void BackToIdle()
    {

        TransitionToState(IdleState);
        transform.position = posBeforeHit;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

    }
    public void SpawnObj(GameObject objToSpawn)
    {

        Instantiate(objToSpawn, WeaponBullets[CurrentWeapon].transform.position, Quaternion.Euler(WeaponBullets[CurrentWeapon].transform.eulerAngles));

    }

    public void TakeDamageFromZombie()
    {

        Health -= 25; TransitionToState(DeadState);


    }


}
