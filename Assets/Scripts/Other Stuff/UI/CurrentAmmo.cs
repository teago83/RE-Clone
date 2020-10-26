using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentAmmo : MonoBehaviour
{
    public Text Ammo;
    public GameObject Player;

    void Update()
    {
        Ammo.text = ("" + Player.GetComponent<PlayerFSM>().Weapons[PlayerFSM.CurrentWeapon].CurrentAmmo);
    }
}
