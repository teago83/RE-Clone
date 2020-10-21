using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item Item;
    public Image Icon;
    public Button RemoveButton;
    public GameObject CurrentAmmo;

    public void AddItem(Item NewItem)
    {
        Item = NewItem;
        Icon.sprite = Item.Icon;
        Icon.enabled = true;

        if (Item.IsRemovable == true)
            RemoveButton.interactable = true;
        else
            RemoveButton.interactable = false;
        if (Item.IsEquippable == true)
            CurrentAmmo.SetActive(true);
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
            if (Item.IsRemovable)
                Inventory.Instance.Remove(Item);
    }
}
