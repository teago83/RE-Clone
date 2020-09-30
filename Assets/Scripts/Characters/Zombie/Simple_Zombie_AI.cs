using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Simple_Zombie_AI : MonoBehaviour
{
    public GameObject ThePlayer;
    NavMeshAgent ZaZomubii;

    void Start()
    {
        ZaZomubii = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        ZaZomubii.SetDestination(ThePlayer.transform.position);
    }

}