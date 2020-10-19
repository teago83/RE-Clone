using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BandAid", menuName = "Inventory/BandAid")]
public class BandAid : Item
{ 
    public override void Use()
    {
        base.Use();
        PlayerFSM.Health += 50;
        Debug.Log("Player's currently recovered health = " + PlayerFSM.Health);
        if (PlayerFSM.Health > PlayerFSM.MaxHealth)
        {
            Debug.Log("Wait, something that's wrong isn't right, the player's health is too high. Let's fix this. \nPlayer's currently recovered health = " + PlayerFSM.MaxHealth);
        }
    }
}
