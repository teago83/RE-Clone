using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject WeakHeartBeats;
    public GameObject StableHeartBeats;
    public Transform ItemsParent;
    Inventory Inventory;
    InventorySlot[] Slots;

    void Start()
    {

        Inventory = Inventory.Instance;
        Inventory.OnItemChangedCallback += UpdateUI;

        Slots = ItemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerFSM.Health >= 75)
        {
            WeakHeartBeats.SetActive(false);
            StableHeartBeats.SetActive(true);
        }
        else
        {
            WeakHeartBeats.SetActive(true);
            StableHeartBeats.SetActive(false);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if (i < Inventory.Items.Count)
            {
                Slots[i].AddItem(Inventory.Items[i]);
            }
            else
            {
                Slots[i].ClearSlot();
            }
        }
    }
}
