using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    private GameObject player;
    [SerializeField]
    private Vector3 offset;

    private void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {

        this.transform.position = player.transform.position + offset;

    }
}
