using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public bool IsOpen;
    public Animator animator;
    public GameObject TheDoors;

    public void OpenDoor()
    {
        if (!IsOpen)
        {
            IsOpen = true;
            Debug.Log("The door is now open!");
            // animator.SetBool("IsOpen", IsOpen);

            TheDoors.GetComponent<Animator>().Play("OpenDoubleDoor");
        }
    }


}
