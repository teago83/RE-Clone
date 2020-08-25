using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{

    public GameObject CameraTURN_ON;
    public GameObject CameraTURN_OFF;

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            CameraTURN_ON.SetActive(true);
            CameraTURN_OFF.SetActive(false);
        }
    }

    
}
