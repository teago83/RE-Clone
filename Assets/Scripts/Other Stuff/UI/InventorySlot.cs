using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item Item;
    public Image Icon;
    public Button RemoveButton;


    public void AddItem(Item NewItem)
    {
        Item = NewItem;
        Icon.sprite = Item.Icon;
        Icon.enabled = true;

        if (Item.type == Item.ItemTypes.Consumable)
            RemoveButton.interactable = true;
        else
            RemoveButton.interactable = false;
        Item.Awake();
    }
    public void ClearSlot()
    {
        Item = null;
        Icon.sprite = null;
        Icon.enabled = false;
        RemoveButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.Instance.Remove(Item);
    }

    public void OnUseButton()
    {
        if (Item)
            Item.Use();
        if (Item.type == Item.ItemTypes.Consumable)
            if (Item.ToBeRemoved == true) 
                Inventory.Instance.Remove(Item); 
    }
}