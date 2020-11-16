using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAIFSM : MonoBehaviour
{

    #region Zombie States

    public ZombieState_Base currentState;
    public readonly ZombieState_Idle statesIdle = new ZombieState_Idle();
    public readonly ZombieState_Patrolling statesPatrol = new ZombieState_Patrolling();
    public readonly ZombieState_Biting statesBiting = new ZombieState_Biting();

    #endregion

    #region Components

    [HideInInspector]
    public NavMeshAgent aIController;
    [HideInInspector]
    public Animator animatorComp;

    #endregion

    #region Numeric values

    public float stillTime;
    [HideInInspector]
    public float currentStillTime;
    public float health;

    #endregion

    [Space]
    [Header("Audios")]

    public AudioSource zombieMoans;
    public AudioSource zombieAttack;



    [HideInInspector]
    public bool isSeeingPlayer;

    public Transform[] Waypoints;
    public Vector3 playerLocation;



    void Start()
    {

        animatorComp = GetComponent<Animator>();
        aIController = GetComponent<NavMeshAgent>();

        ChangeState(statesIdle);

        currentStillTime = stillTime;
    }

    void Update()
    {

        currentState.Update(this);

        if (health <= 0)
        {

            this.GetComponent<ZombieAIFSM>().enabled = false;

        }

    }

    public void ChangeState(ZombieState_Base state)
    {

        currentState = state;
        state.OnEnterState(this);
        Debug.Log("Current state is now " + currentState);

    }

    public void OnTriggerStay(Collider col)
    {

        if (col.CompareTag("Player")) { isSeeingPlayer = true; playerLocation = col.transform.position; }

    }

    private void OnCollisionEnter(Collision collision)
    {

        currentState.OnCollisionEnter(this, collision);

    }


    public void FinishBite()
    {

        animatorComp.SetBool("hitPlayer", false);
        ChangeState(statesIdle);

    }

    private void OnParticleCollision(GameObject other)
    {

        if (other.CompareTag("ShotgunBullet"))
        {

            health -= 35;
            Destroy(other);

        }
        else if (other.CompareTag("HandgunBullet")) { health -= 15; Destroy(other); }

    }

}
