using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        Player.transform.root.position = this.transform.position;
        Player.transform.root.rotation = this.transform.rotation;
    }
}
