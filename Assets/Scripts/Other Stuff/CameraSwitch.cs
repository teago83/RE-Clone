using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{

    public GameObject CameraTURN_ON;
    public GameObject CameraTURN_OFF;
    public static GameObject LastActiveCamera; 
    // This object is used so that the DoorControl script can set the LastActiveCamera off
    // when it instantiates the SceneTransition object. 

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            CameraTURN_ON.SetActive(true);
            CameraTURN_OFF.SetActive(false);
            LastActiveCamera = CameraTURN_ON;
        }
    }

    
}
