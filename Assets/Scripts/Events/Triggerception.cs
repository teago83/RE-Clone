using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerception : MonoBehaviour
{
    public GameObject Trigger;
    private bool TriggeredYet;

    public void TriggerTrigger()
    {
        if (!TriggeredYet)
        {
            Trigger.SetActive(true);
            TriggeredYet = true;
        }
    }
}
