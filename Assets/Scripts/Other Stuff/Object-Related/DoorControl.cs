using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public bool IsOpen = false; // The door will start closed, so this needs to be false. 
    public GameObject Door;
    public GameObject SceneTransitionDoor;   // Use the whole transition scene object that shall be ins-
                                             // tantiated, not the door object that's being interacted with.

    public bool IsLockedDoor; // This is determined in the inspector panel, varying from
    private bool IsInteracting;
    // door to door.
    public bool CanBeOpened;  // For doors that can't be unlocked.
    public bool IsDoubleDoor; // Depending on the kind of door, the animation shall be different
    public bool HaveIMadeTransitionYet = false;
    // Variable so that the game doesn't instantiate multiple SceneTransition objects

    public bool ReadyToOpen = false;
    public float OpeningCooldown = 2f;
    public AudioSource LockedDoorSound;

    public void OpenDoor()
    {
        if (IsLockedDoor)
        {
            IsInteracting = !IsInteracting;
            
            // This is really interesting. If you pick up a variable and set it equal to
            // itself, but with an exclamation mark in front of its name, it will pick its last
            // value and reverse it. That's why the "LockedDoorSound" doesn't play twice
            // when you interact with a locked door. Thank Dullker for that. 

            if (CanBeOpened && PlayerFSM.MiniKeyCount > 0)
            {
                PlayerFSM.MiniKeyCount--;
                Debug.Log("Number of Mini Keys: " + PlayerFSM.MiniKeyCount);
                IsLockedDoor = false;
            }
            else
            {
                if (IsInteracting)
                {
                    LockedDoorSound.Play();
                }
            }
        }

        if (!IsOpen && !IsLockedDoor)
        {
            IsOpen = true;
            Debug.Log("The door is now open!");
            ReadyToOpen = true;
        }

        if (IsOpen && !HaveIMadeTransitionYet)
        {
            CameraSwitch.LastActiveCamera.SetActive(false);
            Instantiate(SceneTransitionDoor, new Vector3(0f, Door.transform.position.y + 50f, 0f), Quaternion.identity);
            HaveIMadeTransitionYet = true;
        }
    }
}