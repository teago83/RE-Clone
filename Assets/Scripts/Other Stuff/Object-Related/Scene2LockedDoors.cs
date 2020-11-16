using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scene2LockedDoors : MonoBehaviour
{

    public static int NumberOfDoorsChecked;
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

        else if (NumberOfDoorsChecked == 1)
        {
            Text.GetComponent<TextMeshPro>().text.Replace("kkj", "ah nao olha la o");
        }
        else if (NumberOfDoorsChecked == 2)
        {
            
        }
        else if (NumberOfDoorsChecked == 3)
        {
            
        }
    }
}
