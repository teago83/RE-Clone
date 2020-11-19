using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{

    public GameObject Zombie;
    public GameObject Item;
    private bool DontDoThisTwiceDummy = true;

    void Update()
    {
        if (Zombie.GetComponent<ZombieAIFSM>().health < 0 && DontDoThisTwiceDummy)
        {
            Instantiate(Item, new Vector3(Zombie.GetComponent<ZombieAIFSM>().transform.position.x, Zombie.GetComponent<ZombieAIFSM>().transform.position.y, Zombie.GetComponent<ZombieAIFSM>().transform.position.z), Quaternion.identity);
            DontDoThisTwiceDummy = false;
        }
    }
}
