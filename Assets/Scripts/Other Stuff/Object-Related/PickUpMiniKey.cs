using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMiniKey : MonoBehaviour
{
    /* Method made so that MiniKeys aren't treated like 
     * regular items, making it so that they don't take up
     * any space in the player's inventory */

    public GameObject MiniKey;

    public void CollectMiniKey()
    {
        PlayerFSM.MiniKeyCount++;
        Destroy(MiniKey);
    }
}
