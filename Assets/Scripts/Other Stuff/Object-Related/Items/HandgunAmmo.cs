using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.PostProcessing;

[CreateAssetMenu(fileName = "HandgunAmmo", menuName = "Inventory/HandgunAmmo")]
public class HandgunAmmo : Item
{

    private GameObject player;


    public override void Use()
    {
        base.Use();

        player = GameObject.FindGameObjectWithTag("Player");
        PlayerFSM playerScript = player.GetComponent<PlayerFSM>();

        int ammoToRecover = playerScript.Weapons[0].MaxAmmo - playerScript.Weapons[0].CurrentAmmo;


        if (ammoToRecover < StatRecovery)
        {

            StatRecovery -= ammoToRecover;

        }
        else
        {
            ammoToRecover = StatRecovery;
            StatRecovery = 0;
        }

        playerScript.Weapons[0].CurrentAmmo += ammoToRecover;


    }
}
