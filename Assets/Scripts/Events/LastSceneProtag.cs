using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastSceneProtag : MonoBehaviour
{
    private GameObject[] LastAreaItems;
    private bool AlreadyActivated;

    private void Start()
    {
        AlreadyActivated = false;
    }

    void Update()
    {
        Debug.Log("Already Activated? " + AlreadyActivated);
        Debug.Log("Current scene's index = " + SceneManager.GetActiveScene().buildIndex);
        LastAreaItems = GameObject.FindGameObjectsWithTag("FinalAreaProtag");

        if (SceneManager.GetActiveScene().buildIndex == 4 && !AlreadyActivated)
        {
            for (int i = 0; i < LastAreaItems.Length; i++)
            {
                LastAreaItems[i].SetActive(true);
            }

            AlreadyActivated = true;
        }
    }
}
