using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.PostProcessing;

[CreateAssetMenu(fileName = "HandgunAmmo", menuName = "Inventory/HandgunAmmo")]
public class HandgunAmmo : Item
{
    public int StatRecovery = 0;
    public int NumberOfAwakes = 0;
    private GameObject player;

    public override void Awake()
    {
        int NumberOfAwakesNeo = 0;

        base.Awake();

        if (NumberOfAwakesNeo == 0 && NumberOfAwakes == 0)
        {
            ToBeRemoved = false;
            StatRecovery = MaxStatRecovery;
            Debug.Log("Starting with the ammo...");
        }

        NumberOfAwakesNeo++;

        if (NumberOfAwakesNeo == 1 && NumberOfAwakes == 0)
        {
            NumberOfAwakes++;
        }
    }

    public override void Use()
    {
        base.Use();

        player = GameObject.FindGameObjectWithTag("Player");
        PlayerFSM playerScript = player.GetComponent<PlayerFSM>();

        int ammoToRecover = playerScript.Weapons[0].MaxAmmo - playerScript.Weapons[0].CurrentAmmo;

        Debug.Log("Current handgun ammo in pack: " + StatRecovery);

        if (ammoToRecover < StatRecovery)
        {
            StatRecovery -= ammoToRecover;
        }
        else
        {
            ammoToRecover = StatRecovery;
            StatRecovery = 0;
        }

        Debug.Log("Handgun ammo in pack after reloading: " + StatRecovery);
        Debug.Log("Ammo that the gun will receive: " + ammoToRecover);


        playerScript.Weapons[0].CurrentAmmo += ammoToRecover;

        Debug.Log("Handgun's current ammo after reloading: " + playerScript.Weapons[0].CurrentAmmo);

        if (StatRecovery == 0)
        {
            NumberOfAwakes = 0; 
            ToBeRemoved = true;
        }
    }
}
