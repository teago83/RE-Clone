using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropKey : MonoBehaviour
{

    public GameObject Zombie;
    public GameObject Key;
    private bool DontDoThisTwiceDummy = true;

    // Update is called once per frame
    void Update()
    {
        if (Zombie.GetComponent<ZombieAIFSM>().health < 0 && DontDoThisTwiceDummy)
        {
            Instantiate(Key, new Vector3(Zombie.GetComponent<ZombieAIFSM>().transform.position.x, Zombie.GetComponent<ZombieAIFSM>().transform.position.y, Zombie.GetComponent<ZombieAIFSM>().transform.position.z), Quaternion.identity);
            DontDoThisTwiceDummy = false;
        }
    }
}
