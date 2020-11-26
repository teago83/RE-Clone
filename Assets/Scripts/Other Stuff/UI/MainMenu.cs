using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Title;
    public AudioSource TitleAudio;
    private float WaitingTime;
    private float WaitingTimeIntro;
    private float CreditsCooldown;
    public bool UserPressedTheButton;
    public GameObject Intro;
    public GameObject Menu;
    public GameObject CreditsScreen;
    private bool StartedIntro;

    private void Start()
    {
        UserPressedTheButton = false;
        StartedIntro = false;
    }

    void Update()
    {
        if (WaitingTime > -1f)
            WaitingTime -= Time.deltaTime;

        if (CreditsCooldown > -1f)
            CreditsCooldown -= Time.deltaTime;

        else if (CreditsCooldown <= 0)
        {
            Menu.SetActive(true);
            CreditsScreen.SetActive(false);
        }

        if (WaitingTime <= 0 && UserPressedTheButton == true)
        {
            if (!StartedIntro)
            {
                Intro.SetActive(true);
                Menu.SetActive(false);
                StartedIntro = true;
            }

            if (WaitingTimeIntro > -1f)
                WaitingTimeIntro -= Time.deltaTime;
            else if (WaitingTimeIntro <= 0)
            {
                StartGame();
            }
        }
    }

    public void StartGame()
    {
        if (UserPressedTheButton == false)
        {
            Title.GetComponent<Animator>().Play("StartGame");
            TitleAudio.Play();
            WaitingTime = 4f;
            WaitingTimeIntro = 45f;
            UserPressedTheButton = true;
        }
        
        if (WaitingTimeIntro <= 0)
        {
            Debug.Log("First scene has been loaded, bruh.");
            PauseMenu.LoadingMainMenu = false; 
            // Turning this bool into false so that the Player doesn't get destroyed
            // whenever the first area is loaded -qqqqqq
            SceneManager.LoadScene("First_Area");
        }
        
    }
    public void QuitGame()
    {
        Debug.Log("QUITTING THE GAME ALREADY??????? I can't believe it.");
        Application.Quit();
    }

    public void Credits()
    {
        CreditsScreen.SetActive(true);
        Menu.SetActive(false);
        CreditsCooldown = 49f;
    }
}
