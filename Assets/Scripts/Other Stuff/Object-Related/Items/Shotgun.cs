using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shotgun", menuName = "Inventory/Shotgun")]
public class Shotgun : Item 
{ 
    public override void Use()
    {
        base.Use();
        PlayerFSM.CurrentWeapon = 1;
        Debug.Log("Current weapon index: " + PlayerFSM.CurrentWeapon);
        // Sets the shotgun as the currently-equipped weapon.
    }
}
