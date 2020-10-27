using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class CurrentlyEquippedWeapon : MonoBehaviour
{
    public Image SlotIcon;
    public Text CurrentAmmo;
    public Text CurrentWeapon;
    public GameObject Player;

    private void Update()
    {
        SlotIcon.sprite = Player.GetComponent<PlayerFSM>().Weapons[PlayerFSM.CurrentWeapon].Icon;
        CurrentWeapon.text = ("Arma Equipada: " + Player.GetComponent<PlayerFSM>().Weapons[PlayerFSM.CurrentWeapon].Name);
        CurrentAmmo.text = ("Munição Atual: " + Player.GetComponent<PlayerFSM>().Weapons[PlayerFSM.CurrentWeapon].CurrentAmmo + " Balas");
    }

}
