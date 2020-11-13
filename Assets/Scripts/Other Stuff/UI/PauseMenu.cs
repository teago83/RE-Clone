using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //public PlayerFSM Player;
    public GameObject PauseMenuKiddo;
    public static bool GamePaused = false;      // It's a static variable so that it can be
                                                // referenced on other scripts
    public static bool LoadingMainMenu = false; // Used so that the player gets destroyed 
                                                // if the MainMenu is loaded
    private GameObject Player;

    void Update()
    {

        Player = GameObject.FindGameObjectWithTag("Player");

        if (Input.GetKeyDown(KeyCode.Escape) && Inventory.InventoryOpen == false && PlayerFSM.IsReading == false && Player.GetComponent<PlayerFSM>().CurrentPlayerState != Player.GetComponent<PlayerFSM>().DeadState)
        {
            if (GamePaused == true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame ()
    {
        Debug.Log("Game was paused, son");
        Time.timeScale = 0f;
        PauseMenuKiddo.SetActive(true);
        GamePaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Back to shooting zombies, kiddo");
        Time.timeScale = 1f;
        PauseMenuKiddo.SetActive(false);
        GamePaused = false;
    }

    public void QuitGame()
    {
        LoadingMainMenu = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Menu");
    }
}
