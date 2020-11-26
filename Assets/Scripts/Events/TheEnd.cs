using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    private int CurrentAmmountOfZombies;
    private int ZombieRecord;
    private float Cooldown;
    private float FadingCooldown;
    private bool AlreadyFading;
    private float OutroCooldown;
    private bool AlreadyOutro;
    public GameObject Outro;
    private GameObject[] Zombies;
    private GameObject Player;
    public GameObject FadingOutScreen;
    public GameObject BGM;
    private bool ShallNotLoadMainMenu;
    private SceneLoader Loader;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        ShallNotLoadMainMenu = true;
    }

    private void Update()
    {
        if (FadingCooldown > -1f)
        {
            FadingCooldown -= Time.deltaTime;
        }
        if (OutroCooldown > -1f)
        {
            OutroCooldown -= Time.deltaTime;
        }
        
        if (ZombieRecord >= 6)
        {
            Player.GetComponent<PlayerFSM>().OnCutscene = true;

            if (!AlreadyFading)
            {
                FadingOutScreen.SetActive(true);
                FadingCooldown = 1.3f;
                AlreadyFading = true;
            }

            if (!AlreadyOutro && FadingCooldown <= 0)
            {
                Outro.SetActive(true);
                OutroCooldown = 46f;
                FadingOutScreen.SetActive(false);
                BGM.SetActive(false);
                ShallNotLoadMainMenu = false;
                AlreadyOutro = true;
            }

            if (!ShallNotLoadMainMenu && OutroCooldown <= 0)
            {
                PauseMenu.LoadingMainMenu = true;
                SceneManager.LoadScene("Main_Menu");
            }
        }

        if (Cooldown == 0f && CurrentAmmountOfZombies < 6)
        {
            Zombies = GameObject.FindGameObjectsWithTag("CountedZombie");
            for (int i = 0; i < Zombies.Length; i++)
            {
                Zombies[i].tag = "Zombie";
            }
            CurrentAmmountOfZombies = 0;
        }

        else if (CurrentAmmountOfZombies >= 6)
        {
            Debug.Log("Deu certo, bicho");
            ZombieRecord = CurrentAmmountOfZombies;
        }

        else if (Cooldown >= -1f)
        {
            Cooldown -= Time.deltaTime;
            
            if (Cooldown < 0f)
            {
                Cooldown = 0f;
                return;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zombie")
        {
            Debug.Log("Pô, tem uns zumbi aqui, fei");
            CurrentAmmountOfZombies++;
            Cooldown = 2f;
            Debug.Log("Number of zombies: " + CurrentAmmountOfZombies);
            other.tag = "CountedZombie";
        }
    }
}
