using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    private int CurrentSceneIndex;

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "TransitionCamera")
        {
            Debug.Log("Next scene, bruh!");
            CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerFSM.IsReading = false;
            SceneManager.LoadScene(CurrentSceneIndex + 1);
        }
    }
}
