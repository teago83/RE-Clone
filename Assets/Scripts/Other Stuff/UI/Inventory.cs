using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class Inventory : MonoBehaviour
{
    public GameObject TheInventory;
    public static bool InventoryOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && PauseMenu.GamePaused == false && PlayerFSM.IsReading == false)
        {
            if (InventoryOpen == true)
            {
                CloseInventory();
            }
            else
            {
                OpenInventory();
            }
        }
    }

    void OpenInventory()
    {
        Debug.Log("The inventory has been opened, kiddo.");
        Time.timeScale = 0f;
        TheInventory.SetActive(true);
        InventoryOpen = true;
    }

    public void CloseInventory()
    {
        Debug.Log("You don't have any bloody time to check your items, dude.");
        Time.timeScale = 1f;
        TheInventory.SetActive(false);
        InventoryOpen = false;
    }
}
