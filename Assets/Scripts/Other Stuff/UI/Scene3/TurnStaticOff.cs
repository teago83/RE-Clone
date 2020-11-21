using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStaticOff : MonoBehaviour
{
    public GameObject Static;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Static.SetActive(false);
        }
    }
}
