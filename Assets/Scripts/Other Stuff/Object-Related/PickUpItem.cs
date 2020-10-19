using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    public Item Item;

    public void Pickup()
    {
        if (Inventory.NumberOfItems == Inventory.MaxSpace)
        {
            Debug.Log("Not enough space, stranger.");
            return;
        }
        else
        {
            Debug.Log("Picked up a " + Item.ItemName);
            Inventory.Instance.Add(Item);
            Destroy(gameObject);
        }
    }
}
