using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string ItemName = "New Name";
    public Sprite Icon = null;
    public int Quantity = 0;
    public bool IsRemovable = false;   // Bool made so that the player can't discard key items,
                                       // such as literal keys, guns, etc. 

    public int HealthRecovery = 0;     // For herbs, potions and what not. 
    public bool IsEquippable = false;  // For weaponry. 
}
