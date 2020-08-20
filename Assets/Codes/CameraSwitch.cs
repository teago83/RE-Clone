using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{

    public GameObject CameraOne;
    public GameObject CameraTwo;

    // Update is called once per frame
    
    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            CameraOne.SetActive(true);
            CameraTwo.SetActive(false);
        }
    }

    
}
