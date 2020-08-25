using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject ThePlayer;
    public bool IsMoving;
    public bool IsRunning;
    public float HorizontalMovement;
    public float VerticalMovement;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) 
        {
            IsMoving = true;
            ThePlayer.GetComponent<Animator>().Play("Walk");
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
}
