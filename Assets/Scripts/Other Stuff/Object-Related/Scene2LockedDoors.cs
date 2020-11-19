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
    public AudioSource LockedDoorSound;
    private bool IsInteracting;

    public void CheckDoor()
    {
        IsInteracting = !IsInteracting;

        Debug.Log("Name of the door: " + this.name + "\nChecked Already? " + CheckedAlready);
        Debug.Log("Number of doors that were checked: " + NumberOfDoorsChecked);

        if (CheckedAlready == false && NumberOfDoorsChecked < 4)
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
            Text.text = "Duas portas trancadas agora? Mas que porcaria...";
        }
        if (NumberOfDoorsChecked == 3)
        {
            Text.text = "Agora são três? Desisto dessas portas.";
        }
        if (NumberOfDoorsChecked == 4)
        {
            Text.text = "Não vou mais tentar abrir essas portas.";
        }

        if (IsInteracting && NumberOfDoorsChecked < 4)
            LockedDoorSound.Play();

        if (NumberOfDoorsChecked == 3)
        {
            NumberOfDoorsChecked++;
        }
    }
}
