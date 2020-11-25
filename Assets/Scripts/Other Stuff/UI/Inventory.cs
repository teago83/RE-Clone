using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    // Some sort of singleton pattern, as said Brackeys. It's used to make it easier for the inventory 
    // to be accessed by other classes and to check if there's only one inventory object. 

    public HandgunItem Handgun;
    public GameObject TheInventory;
    public static bool InventoryOpen = false;
    public List<Item> Items = new List<Item>();
    public static int NumberOfItems = 0;
    public static int MaxSpace = 6;

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;
    // As says Brackeys, "a delegate is basically an event that you can subscribe different methods to;
    // when you trigger the event, all of the subscribed methods will be called."
    private GameObject PlayerNeo;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Hey, there's more than one instance of the inventory. There's definitely something wrong.");
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        Items.Add(Handgun);
        NumberOfItems = Items.Count;
    }

    void Update()
    {
        PlayerNeo = GameObject.FindGameObjectWithTag("Player");

        if (Input.GetKeyDown(KeyCode.F) && PauseMenu.GamePaused == false && PlayerFSM.IsReading == false && PlayerNeo.GetComponent<PlayerFSM>().CurrentPlayerState != PlayerNeo.GetComponent<PlayerFSM>().DeadState && PlayerNeo.GetComponent<PlayerFSM>().OnCutscene == false)
        {
            if (InventoryOpen)
                CloseInventory();
            else
                OpenInventory();
        }
    }

    void OpenInventory()
    {
        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();


        Time.timeScale = 0f;
        TheInventory.SetActive(true);
        InventoryOpen = true;
    }

    public void CloseInventory()
    {
        Time.timeScale = 1f;
        TheInventory.SetActive(false);
        InventoryOpen = false;
    }

    public void Add(Item item)
    {
        Items.Add(item);
        NumberOfItems = Items.Count;
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
        NumberOfItems = Items.Count;
        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();
    }
}
