using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    public enum ItemTypes {Equippable, Consumable, KeyItem }
    public ItemTypes type;
    public string ItemName = "New Name";
    public Sprite Icon = null;
    public int StatRecovery = 0;



    //public int Quantity = 0;
    //public bool IsRemovable = false;   // Bool made so that the player can't discard key items, such as literal keys, guns, etc.  
    //public bool IsEquippable = false;  // For weaponry. 

    public virtual void Use()
    {
        Debug.Log("Using " + ItemName);
    }
}
