using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurnOn : MonoBehaviour
{ 
    public GameObject CameraTURN_ON;
    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            CameraTURN_ON.SetActive(true);
        } 
    }
}
