using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Title;
    public AudioSource TitleAudio;
    public float WaitingTime;
    public bool UserPressedTheButton;

    // delete later
    public void TestAudio()
    {
        TitleAudio.Play();
    }

    private void Start()
    {
        UserPressedTheButton = false;
    }

    void Update()
    {
        if (WaitingTime > -1f)
        {
            WaitingTime -= Time.deltaTime;
        }
        if (WaitingTime <= 0 && UserPressedTheButton == true)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        if (UserPressedTheButton == false)
        {
            Title.GetComponent<Animator>().Play("StartGame");
            TitleAudio.Play();
            WaitingTime = 3.5f;
            UserPressedTheButton = true;
        }
        
        if (WaitingTime <= 0)
        {
            Debug.Log("First scene has been loaded, bruh.");
            SceneManager.LoadScene("First_Area");
        }
        
    }
    public void QuitGame()
    {
        Debug.Log("QUITTING THE GAME ALREADY??????? I can't believe it.");
        Application.Quit();
    }
}
