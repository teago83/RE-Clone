using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    public GameObject Zombie;
    public GameObject Door;
    public GameObject Trigger;
    public GameObject ReadInteraction;
    public GameObject CutsceneRectangles;
    private GameObject Player;
    public GameObject CurrentSong;
    public GameObject NextSong;

    public AudioSource UnlockDoorSFX;

    private float UnlockingCooldown = 2.5f;
    private bool AlreadyUnlocked = false;
    private bool AlreadyPlayedSound = false;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (UnlockingCooldown <= 0)
        {
            Door.GetComponent<DoorControl>().IsLockedDoor = false;
            CutsceneRectangles.SetActive(false);
            NextSong.SetActive(true);
            Player.GetComponent<PlayerFSM>().OnCutscene = false;
            Trigger.SetActive(false);
        }

        else if (Zombie.GetComponent<ZombieAIFSM>().health <= 0)
        {
            if (CutsceneRectangles.activeSelf == false)
            {
                ReadInteraction.SetActive(false);
                CutsceneRectangles.SetActive(true);
                CurrentSong.SetActive(false);
            }

            UnlockingCooldown -= Time.deltaTime;

            if (!AlreadyUnlocked)
            {
                Player.GetComponent<PlayerFSM>().OnCutscene = true;
                AlreadyUnlocked = true;
            }

            if (!AlreadyPlayedSound && UnlockingCooldown <= 1f)
            {
                UnlockDoorSFX.Play();
                AlreadyPlayedSound = true;
            }
        }
    }
}
