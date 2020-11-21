using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    public GameObject TVScreen;
    public GameObject StaticNoise;
    public GameObject OnButton;
    public GameObject OffButton;

    private bool TVOn;

    public void PressButton()
    {
        if (TVOn)
        {
            TurnOff();
            return;
        }
            
        if (!TVOn)
        {
            TurnOn();
            return;
        }
            
    }

    private void TurnOn()
    {
        TVScreen.SetActive(true);
        StaticNoise.SetActive(true);
        OnButton.SetActive(true);
        OffButton.SetActive(false);
        TVOn = true;
    }
    private void TurnOff()
    {
        TVScreen.SetActive(false);
        StaticNoise.SetActive(false);
        OnButton.SetActive(false);
        OffButton.SetActive(true);
        TVOn = false;
    }
}
