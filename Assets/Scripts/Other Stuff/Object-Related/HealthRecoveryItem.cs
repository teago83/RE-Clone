using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Health Recovery Item", menuName = "Inventory/HealthRecoveryItem")]
public class HealthRecoveryItem : ScriptableObject
{
    public string ItemName = "New Name";
    public Image Icon = null;
    public int Quantity = 0;
    public int HealthRecovery = 0;   
}
