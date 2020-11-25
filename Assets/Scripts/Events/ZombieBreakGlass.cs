using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBreakGlass : MonoBehaviour
{
    public GameObject Vidrao;
    public GameObject VidraoQuebrado;
    public AudioSource GlassShattering;
    public GameObject Trigger;
    public GameObject GlassZombie;
    public GameObject RealZombie;
    public GameObject CutsceneRectangles;
    private float BreakingCooldown = 2;
    private bool CanBatatar = false;
    private bool AlreadyBroken = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            CanBatatar = true;
    }

    private void Update()
    {
        if (CanBatatar)
        {
            if (BreakingCooldown <= 0)
            {
                CutsceneRectangles.SetActive(false);
                PlayerFSM.IsReading = false;
                Vidrao.SetActive(false);
                VidraoQuebrado.SetActive(true);
                GlassZombie.SetActive(false);
                RealZombie.SetActive(true);
                Trigger.SetActive(false);
            }

            if (BreakingCooldown >= 0)
            {
                if (CutsceneRectangles.activeSelf == false)
                    CutsceneRectangles.SetActive(true);

                PlayerFSM.IsReading = true;
                BreakingCooldown -= Time.deltaTime;
            }

            if (!AlreadyBroken)
            {
                GlassShattering.Play();
                AlreadyBroken = true;
            }
        }
    }
}
