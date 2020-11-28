using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public bool CanEnd;
    private bool CanReallyEnd;
    private bool AlreadyFading;
    public GameObject FadingOutScreen;
    private float FadingCooldown;

    private float OutroCooldown;
    private bool AlreadyOutro;
    public GameObject Outro;

    private bool ShallNotLoadMainMenu;

    public GameObject BGM;

    private GameObject Player;

    private void Start()
    {
        CanEnd = false;
        CanReallyEnd = false;
        AlreadyFading = false;
        AlreadyOutro = false;
        ShallNotLoadMainMenu = true;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void EndItAlready()
    {
        if (CanEnd)
            CanReallyEnd = true;
    }

    public void Update()
    {
        if (CanReallyEnd)
        {
            Player.GetComponent<PlayerFSM>().OnCutscene = true;

            if (!AlreadyFading)
            {
                FadingOutScreen.SetActive(true);
                FadingCooldown = 1.3f;
                AlreadyFading = true;
            }

            if (FadingCooldown > -1f)
            {
                FadingCooldown -= Time.deltaTime;
            }
            if (OutroCooldown > -1f)
            {
                OutroCooldown -= Time.deltaTime;
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
    }
}

/*public class TheEnd : MonoBehaviour
{
    
    private float Cooldown;
    private float FadingCooldown;
    private bool AlreadyFading;
    
    private GameObject[] Zombies;
    private GameObject Player;
    private GameObject FadingOutScreen;
    private SceneLoader Loader;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
        ShallNotLoadMainMenu = true;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            BGM = GameObject.FindGameObjectWithTag("BGM");

            

            if (ZombieRecord >= 6)
            {
                

                if (!AlreadyFading)
                {
                    FadingOutScreen.SetActive(true);
                    FadingCooldown = 1.3f;
                    AlreadyFading = true;
                }

                
            }
        }
    }
}
*/