using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public bool IsOpen = false; // The door will start closed, so this needs to be false. 
    public Animator animator;
    public GameObject Door;

    public void OpenDoor()
    {
        if (!IsOpen)
        {
            IsOpen = true;
            Debug.Log("The door is now open!");
            // animator.SetBool("IsOpen", IsOpen);
            

            Door.GetComponent<Animator>().Play("OpenDoubleDoor");
        }
    }


}
