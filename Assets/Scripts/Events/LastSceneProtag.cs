using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastSceneProtag : MonoBehaviour
{
    public GameObject Spotlight, Collider;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Final_Area")
        {
            Spotlight.SetActive(true);
            Collider.SetActive(true);
        }
        else
        {
            Spotlight.SetActive(false);
            Collider.SetActive(false);
        }
    }
}
