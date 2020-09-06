using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInteraction : MonoBehaviour
{
    public bool IsReading = false;
    public GameObject Text;

    public void ReadObjectText()
    {
        if (!IsReading)
        {
            IsReading = true;
            Debug.Log("The player is now reading.");
            Time.timeScale = 0;
            Text.SetActive(true);
        }
        /*else
        {
            IsReading = false;
            Debug.Log("The player isn't reading anymore.");
            Time.timeScale = 1;
            Text.SetActive(false);
        }*/

    }

}
