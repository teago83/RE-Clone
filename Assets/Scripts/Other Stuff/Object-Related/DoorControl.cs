using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public bool IsOpen = false; 
    public GameObject Door;
    public GameObject SceneTransitionDoor;   // Use the whole transition scene object that shall be ins-
                                             // tantiated, not the door object that's being interacted with.
    private GameObject Player;
    public GameObject ReadInteracion;

    public bool IsLockedDoor; 
    private bool IsInteracting;
    public bool CanBeOpened;  // For doors that can't be unlocked.
    public bool HaveIMadeTransitionYet = false; // Variable so that the game doesn't instantiate multiple SceneTransition objects
    public float OpeningCooldown = 2f;
    public AudioSource LockedDoorSound;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        if (PlayerFSM.MiniKeyCount > 0)
        {
            ReadInteracion.SetActive(false);
        }
    }

    public void OpenDoor()
    {
        if (IsLockedDoor)
        {
            IsInteracting = !IsInteracting;

            // This is really interesting. If you pick up a variable and set it equal to
            // itself, but with an exclamation mark in front of its name, it will pick its last
            // value and reverse it. That's why the "LockedDoorSound" doesn't play twice
            // when you interact with a locked door. Thank Dullke for that. 

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
        }

        if (IsOpen && !HaveIMadeTransitionYet)
        {
            if (CameraSwitch.LastActiveCamera != null)
            {
                CameraSwitch.LastActiveCamera.SetActive(false);
            }
            Instantiate(SceneTransitionDoor, new Vector3(Door.transform.position.x, Door.transform.position.y + 50f, Door.transform.position.z), Quaternion.identity);
            Player.GetComponent<PlayerFSM>().OnCutscene = true;
            Player.transform.Translate(new Vector3(Player.transform.position.x, Player.transform.position.y + 100f, Player.transform.position.z));
            HaveIMadeTransitionYet = true;
        }
    }
}