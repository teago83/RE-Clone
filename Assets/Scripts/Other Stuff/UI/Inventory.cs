using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    // Some sort of singleton pattern, as said Brackeys. It's used to make it easier for the inventory 
    // to be accessed by other classes and to check if there's only one inventory object. 

    public GameObject TheInventory;
    public static bool InventoryOpen = false;
    public List<Item> Items = new List<Item>();
    public int MaxSpace = 6; 

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Hey, there's more than one instance of the inventory. There's definitely something wrong.");
            return;
        }
        Instance = this;
    }

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

    public void Add(Item item)
    {
        if (Items.Count >= MaxSpace)
        {
            Debug.Log("Not enough space, stranger.");
            return;
        }
        else
        {
            Items.Add(item);
        }
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }
}
