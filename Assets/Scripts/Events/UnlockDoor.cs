using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    public GameObject Zombie;
    public GameObject Door;
    public AudioSource UnlockDoorSFX;
    public GameObject Trigger;

    private float UnlockingCooldown = 2;
    public GameObject CutsceneRectangles; 

    void Update()
    {
        if (UnlockingCooldown <= 0)
        {
            Door.GetComponent<DoorControl>().IsLockedDoor = false;
            UnlockDoorSFX.Play();
            CutsceneRectangles.SetActive(false);
            Trigger.SetActive(false);
        }

        else if (Zombie.GetComponent<ZombieAIFSM>().health <= 0)
        {
            if (CutsceneRectangles.activeSelf == false)
                CutsceneRectangles.SetActive(true);

            UnlockingCooldown -= Time.deltaTime;
        }
    }
}
