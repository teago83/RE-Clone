using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scene2LockedDoors : MonoBehaviour
{

    public static int NumberOfDoorsChecked = 0;
    private bool CheckedAlready = false;
    public GameObject Text;


    public void Update()
    {
        if (CheckedAlready == false)
        {
            NumberOfDoorsChecked++;
            CheckedAlready = true;
            Debug.Log("NumberOfDoorsChecked == " + NumberOfDoorsChecked);
            Debug.Log("CheckedAlready == true");
        }

        if (NumberOfDoorsChecked == 1)
        {
            Text.GetComponent<TextMeshPro>().text = "aaa";
        }
        else if (NumberOfDoorsChecked == 2)
        {
            Text.GetComponent<TextMeshPro>().text = "bbb";
        }
        else if (NumberOfDoorsChecked == 3)
        {
            Text.GetComponent<TextMeshPro>().text = "ccc";
        }
    }
}
