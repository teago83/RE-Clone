using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateFadingScreen : MonoBehaviour
{
    private float deletingCooldown;

    private void Start()
    {
        deletingCooldown = 1.3f;
    }

    void Update()
    {
        if (deletingCooldown > 0)
        {
            deletingCooldown -= Time.deltaTime;
        }
        else
        {
            GameObject fadingScreen = GameObject.FindGameObjectWithTag("FadingScreen");
            fadingScreen.SetActive(false);
        }
    }
}