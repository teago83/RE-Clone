using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Simple_Zombie_AI : MonoBehaviour
{
    //public GameObject Zombie;
    //public bool IsFollowingPlayer = false;
    public GameObject ThePlayer;
    NavMeshAgent ZaZomubii;

    void Start()
    {
        ZaZomubii = GetComponent<NavMeshAgent>();
    }

    void Update()
    { 
        //while (IsFollowingPlayer == true) 
        //{
        //    Zombie.GetComponent<Animator>().Play("Walking");
            ZaZomubii.SetDestination(ThePlayer.transform.position);
        //}
        //if (IsFollowingPlayer == false)
        //{
        //    Zombie.GetComponent<Animator>().Play("Zombie Idle");
            //ZaZomubii.SetDestination(Zombie.transform.position);
        //}
    }

    /*private void OnTriggerEnter(Collider other)
    {
        while (other.tag == "Player")
        {
            IsFollowingPlayer = true;
        }
        //if (other.tag != "Player" && 
    }

    IEnumerator TogglePlayerFollow()
    {
        yield return new WaitForSeconds(5);
        IsFollowingPlayer = false;
    }*/

}

/*  public GameObject CameraTURN_ON;
    public GameObject CameraTURN_OFF;

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            CameraTURN_ON.SetActive(true);
            CameraTURN_OFF.SetActive(false);
        }
    }
*/

/*
 public class PlayerMovement : MonoBehaviour
{

    public GameObject ThePlayer;
    public bool IsMoving;
    public bool IsRunning;
    public bool IsWalkingBack = false;
    public float HorizontalMovement;
    public float VerticalMovement;

    // Update is called once per frame
    void Update()
    {
        //Just so you know, the basic difference between 'GetButton' and 'GetKey' is that
        //GetKey can tell when you're holding down a button. Or so says Jimmy... 
        if (Input.GetKey(KeyCode.LeftShift))
        {
            IsRunning = true;
        }
        else
        {
            IsRunning = false;
        }

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) 
        {
            IsMoving = true;

            if (Input.GetButton("SKey"))
            {
                IsWalkingBack = true; 
                ThePlayer.GetComponent<Animator>().Play("WalkBack");
            }
            else
            {
                IsWalkingBack = false;
                if (IsRunning == false)
                {
                    ThePlayer.GetComponent<Animator>().Play("Walk");
                }
                if (IsRunning == true && IsWalkingBack == false)
                {
                    ThePlayer.GetComponent<Animator>().Play("Run");
                    HorizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * 145f;
                    VerticalMovement = Input.GetAxis("Vertical") * Time.deltaTime * 8f;
                    ThePlayer.transform.Rotate(0, HorizontalMovement, 0);
                    ThePlayer.transform.Translate(0, 0, VerticalMovement);
                }
                
            }

            HorizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * 150f;
            VerticalMovement = Input.GetAxis("Vertical") * Time.deltaTime * 4f;
            ThePlayer.transform.Rotate(0, HorizontalMovement, 0);
            ThePlayer.transform.Translate(0, 0, VerticalMovement);
        }
        else
        {
            IsMoving = false;
            ThePlayer.GetComponent<Animator>().Play("Idle");
        }
                       
    }
}*/