using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakGlass : MonoBehaviour
{
    public GameObject Vidrao;
    public GameObject VidraoQuebrado;
    public GameObject Trigger;
    public GameObject GlassZombie;
    public GameObject RealZombie;
    public GameObject CutsceneRectangles;
    private GameObject Player;
    public GameObject CurrentSong;
    public GameObject NextSong;

    public AudioSource GlassShattering;
    
    private float BreakingCooldown = 2;
    private bool CanBatatar = false;
    private bool AlreadyBroken = false;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            CanBatatar = true;
    }

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (CanBatatar)
        {
            if (BreakingCooldown <= 0)
            {
                CutsceneRectangles.SetActive(false);
                Player.GetComponent<PlayerFSM>().OnCutscene = false;
                NextSong.SetActive(true);
                Vidrao.SetActive(false);
                VidraoQuebrado.SetActive(true);
                GlassZombie.SetActive(false);
                RealZombie.SetActive(true);
                Trigger.SetActive(false);
            }

            if (BreakingCooldown >= 0)
            {
                if (CutsceneRectangles.activeSelf == false)
                {
                    CurrentSong.SetActive(false);
                    CutsceneRectangles.SetActive(true);
                }

                Player.GetComponent<PlayerFSM>().OnCutscene = true;
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
