using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public GameObject GameOverUI;

    public void OnRetry()
    {
        PauseMenu.LoadingMainMenu = true;
        SceneManager.LoadScene("Main_Menu");
    }

    public void OnQuit()
    {
        Debug.Log("Oh no, the player's trying to quit the game!!!!!!!!!!! What can I do?????");
        Application.Quit();
    }

    private void Update()
    {
        if (PlayerFSM.Health <= 0)
        {
            GameOverUI.SetActive(true);
        }
    }
}
