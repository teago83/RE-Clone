using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scene2LockedDoors : MonoBehaviour
{

    public static int NumberOfDoorsChecked;
    private bool CheckedAlready = false;
    public TMP_Text Text;

    public void CheckDoor()
    {

        Debug.Log("Name of the door: " + this.name + "\nChecked Already? " + CheckedAlready);
        Debug.Log("Number of doors that were checked: " + NumberOfDoorsChecked);

        if (CheckedAlready == false && NumberOfDoorsChecked < 3)
        {
            NumberOfDoorsChecked++;
            CheckedAlready = true;
        }

        if (NumberOfDoorsChecked == 1)
        {
            Text.text = "Trancada...";
        }
        if (NumberOfDoorsChecked == 2)
        {
            Text.text = "Mais outra porta trancada...";
        }
        if (NumberOfDoorsChecked == 3)
        {
            Text.text = "Não vou mais tentar abrir essas portas.";
        }
    }
}
