using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BandAid", menuName = "Inventory/BandAid")]
public class BandAid : Item
{
    public override void Awake()
    {
        base.Awake();
        ToBeRemoved = false;
    }

    public override void Use()
    {
        base.Use();
        PlayerFSM.Health += MaxStatRecovery;
        Debug.Log("Player's currently recovered health = " + PlayerFSM.Health);
        ToBeRemoved = true;
    }
}
