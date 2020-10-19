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
        if (Zombie.GetComponent<ZombieBehaviourFSM>().Health < 0 && DontDoThisTwiceDummy)
        {
            Instantiate(Key, new Vector3(Zombie.GetComponent<ZombieBehaviourFSM>().transform.position.x, Zombie.GetComponent<ZombieBehaviourFSM>().transform.position.y, Zombie.GetComponent<ZombieBehaviourFSM>().transform.position.z), Quaternion.identity);
            DontDoThisTwiceDummy = false;
        }
    }
}
