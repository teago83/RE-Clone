using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    public HealthRecoveryItem Item;

    public void Pickup()
    {
        Debug.Log("Picked up a " + Item.ItemName);
        Destroy(gameObject);
    }
}
