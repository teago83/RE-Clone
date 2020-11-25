using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInteraction : MonoBehaviour
{
    public GameObject Text;

    public void ReadObjectText()
    {
        if (PlayerFSM.IsReading == false)
        {
            PlayerFSM.IsReading = true;
            Debug.Log("The player is now reading.");
            Time.timeScale = 0;
            Text.SetActive(true);
        }
        else
        {
            PlayerFSM.IsReading = false;
            Debug.Log("The player isn't reading anymore.");
            Time.timeScale = 1;
            Text.SetActive(false);
        }

    }

}
