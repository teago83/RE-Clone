using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    public Item Item;

    public void Pickup()
    {
        Debug.Log("Picked up a " + Item.ItemName);
        Inventory.Instance.Add(Item);
        Destroy(gameObject);
    }
}
