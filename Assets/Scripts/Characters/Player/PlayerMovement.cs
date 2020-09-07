using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject ThePlayer;
    public bool IsMoving;
    public bool isAbleToControl;
    public bool IsRunning;
    public bool IsWalkingBack = false;
    public float HorizontalMovement;
    public float VerticalMovement;

    Rigidbody rB;

    private Animator anims;

    private void Start()
    {

        anims = GetComponent<Animator>();

        rB = GetComponent<Rigidbody>();

    }

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
                anims.Play("WalkBack");
            }
            else
            {
                IsWalkingBack = false;
                if (IsRunning == false)
                {
                    anims.Play("Walk");
                }
                if (IsRunning == true && IsWalkingBack == false)
                {
                    anims.Play("Run");
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
            anims.Play("Idle");
        }
                       
    }
}
