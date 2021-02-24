using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapons : MonoBehaviour
{
    public GameObject attackEffect;
    public Transform equippedItemPosition;

    public abstract void LightAttack();
    public abstract void HeavyAttack();
    public abstract void SpecialAttack();
    public virtual void AttackInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LightAttack();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            HeavyAttack();
        }
        if (Input.GetMouseButtonDown(1))
        {
            SpecialAttack();
        }
    }
}
