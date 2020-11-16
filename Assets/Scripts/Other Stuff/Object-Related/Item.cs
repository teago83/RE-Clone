using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    public enum ItemTypes { Equippable, Consumable, KeyItem }
    public ItemTypes type;
    public string ItemName = "New Name";
    public Sprite Icon = null;
    public int MaxStatRecovery = 0;
    public bool ToBeRemoved = false; // When an item's local stat recovery variable reaches 0, 
                                     // this bool shall become true, triggering the item's removal.



    //public int Quantity = 0;
    //public bool IsRemovable = false;   // Bool made so that the player can't discard key items, such as literal keys, guns, etc.  
    //public bool IsEquippable = false;  // For weaponry. 

    public virtual void Awake()
    {

    }

    public virtual void Use()
    {
        Debug.Log("Using " + ItemName);
    }
}
