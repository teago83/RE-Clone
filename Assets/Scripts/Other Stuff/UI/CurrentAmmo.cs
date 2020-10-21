using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentAmmo : MonoBehaviour
{
    public Text Ammo;

    void Update()
    {
        Ammo.text = ("" + PlayerFSM.CurrentPistolAmmo);
    }
}
