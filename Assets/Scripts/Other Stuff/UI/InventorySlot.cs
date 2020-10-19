using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item Item;
    public Image Icon;

    public void AddItem(Item NewItem)
    {
        Item = NewItem;
        Icon.sprite = Item.Icon;
        Icon.enabled = true;
    }
    public void ClearSlot()
    {
        Item = null;
        Icon.sprite = null;
        Icon.enabled = false; 
    }
}
