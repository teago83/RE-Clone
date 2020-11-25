using System;
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


        ZombieState_Biting.Bite += AttackPlayer;
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

            animatorComp.SetTrigger("die");
            aIController.enabled = false;
            this.GetComponent<ZombieAIFSM>().enabled = false;
            this.GetComponent<CapsuleCollider>().enabled = false;
            zombieMoans.Stop();
            zombieAttack.Stop();
        }

        if (PlayerFSM.isAlive == false) { animatorComp.SetBool("isPlayerDead", true); }

    }

    public void ChangeState(ZombieState_Base state)
    {

        currentState = state;
        state.OnEnterState(this);

    }

    public void OnTriggerStay(Collider col)
    {

        if (col.CompareTag("Player"))
        {
            isSeeingPlayer = true; // playerLocation = col.transform.position;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        currentState.OnCollisionEnter(this, collision);

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

    public void FinishBite()
    {

        animatorComp.SetBool("hitPlayer", false);
        ZombieState_Biting.Bite -= AttackPlayer;
        ChangeState(statesIdle);

    }


    public void AttackPlayer()
    {
        transform.LookAt(FindObjectOfType<PlayerFSM>().transform);
        animatorComp.SetBool("hitPlayer", true);
        zombieAttack.Play();
        aIController.ResetPath();
        Debug.Log("I'm biting nhom nhom");
    }

    public void DisableCollider()
    {

        this.GetComponent<CapsuleCollider>().enabled = false;

    }

}
