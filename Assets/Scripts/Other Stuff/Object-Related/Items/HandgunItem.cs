using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Handgun", menuName = "Inventory/Handgun")]
public class HandgunItem : Item
{
    public override void Use()
    {
        base.Use();
        PlayerFSM.CurrentWeapon = 0;
        Debug.Log("Current weapon index: " + PlayerFSM.CurrentWeapon);
        // Sets the handgun as the currently-equipped weapon.
    }
}
