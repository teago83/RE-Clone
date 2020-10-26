using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : ScriptableObject
{
    public string Name;
    public int Damage;
    public int MaxAmmo;
    public int CurrentAmmo;
    public float ShootingRange;
    public float ShootingCooldown;
    public string FiringAnimation; // Used to reference either the "Shooting Handgun" or the "Shooting Shotgun" animations
    public float FiringAnimationCooldown;
    public string AimingAnimation; 
}
