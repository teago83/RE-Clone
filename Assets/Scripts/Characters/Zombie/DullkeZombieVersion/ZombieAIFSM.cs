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
    float Speed;

    #endregion

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


    public void GrabPlayer()
    {
        /*This method is not working yet*/
        ChangeState(statesBiting);

    }

}
