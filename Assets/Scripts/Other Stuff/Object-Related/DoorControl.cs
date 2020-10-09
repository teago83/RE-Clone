using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public bool IsOpen = false; // The door will start closed, so this needs to be false. 
    public Animator Anime;
    public GameObject Door;
    public bool IsLockedDoor; // This is determined in the inspector panel, varying from
                              // door to door.
    public bool CanBeOpened;  // For doors that can't be unlocked.
    public bool IsDoubleDoor; // Depending on the kind of door, the animation shall be different
    private string Open;

    public bool ReadyToOpen = false;
    public float OpeningCooldown = 2f;
    public AudioSource OpeningDoorSound;
    public AudioSource LockedDoorSound;

    private void Start()
    {
        Anime = GetComponent<Animator>();
    }

    void Update()
    {
        if (OpeningCooldown > 0 && ReadyToOpen == true)
        {
            OpeningCooldown -= Time.deltaTime;
        }
        if (OpeningCooldown <= 0)
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        if (IsDoubleDoor)
        {
            Open = "OpenDoubleDoor";
        }
        else
        {
            Open = "OpenDoor";
        }

        if (IsLockedDoor)
        {
            if (CanBeOpened)
            {
                if (PlayerFSM.MiniKeyCount > 0)
                {
                    PlayerFSM.MiniKeyCount--;
                    IsLockedDoor = false;
                }
            }

            LockedDoorSound.Play();
        }

        if (!IsOpen && !IsLockedDoor)
        {
            IsOpen = true;
            Debug.Log("The door is now open!");
            OpeningDoorSound.Play();
            ReadyToOpen = true;
        }

        if (OpeningCooldown <= 0f)
        {
            Anime.Play(Open);
        }
    }
}