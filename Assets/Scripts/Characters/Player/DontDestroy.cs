using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        GameObject[] Objects = GameObject.FindGameObjectsWithTag("Player");

        if (Objects.Length > 1)
        {
            Destroy(this.transform.root.gameObject);
        }

        DontDestroyOnLoad(this.transform.root.gameObject);
    }
}