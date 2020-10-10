using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    public GameObject Item;
    public string ItemType;

    public void Collect(string ItemType)
    {
        //if (Inventory.AcceptItem)
        //{
            if (ItemType == "PistolAmmo")
            {
                PlayerFSM.CurrentPistolAmmo += 15;
            }
            else if (ItemType == "ShotgunAmmo")
            {
                PlayerFSM.CurrentShotgunAmmo++;
            }
            else if (ItemType == "MiniKey")
            {
                PlayerFSM.MiniKeyCount++;
                Debug.Log("Number of Mini Keys: " + PlayerFSM.MiniKeyCount);
            }

            Destroy(Item);
        //}
    }
}
