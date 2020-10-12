using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Update()
    {
        GameObject[] Objects = GameObject.FindGameObjectsWithTag("Player");

        if (Objects.Length > 1 || PauseMenu.LoadingMainMenu)
        {
            Destroy(this.transform.root.gameObject);
        }

        DontDestroyOnLoad(this.transform.root.gameObject);
    }
}