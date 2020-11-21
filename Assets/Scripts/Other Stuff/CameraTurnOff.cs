using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurnOff : MonoBehaviour
{ 
    public GameObject CameraTURN_OFF;
    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            CameraTURN_OFF.SetActive(false);
        } 
    }
}
