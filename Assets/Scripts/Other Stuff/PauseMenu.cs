using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuKiddo;
    public static bool GamePaused = false; // It's a static variable so that it can be
                                           // referenced on other scripts

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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

    public void QuitGame(string SceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneName);
    }
}
