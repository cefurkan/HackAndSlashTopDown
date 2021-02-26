using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapons : MonoBehaviour
{
    //public enum CurrentWeapon
    //{
    //    Bow,
    //    Blade,
    //    Gun,
    //    Spear
    //}
    //private CurrentWeapon currentWeapon;


    public GameObject attackEffect;
    public Transform equippedItemPosition;

    public abstract void LightAttack();
    public abstract void HeavyAttack();
    public abstract void SpecialAttack();

}
