using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapons, IRangedWeapons
{
    public GameObject Projectile { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void Fire()
    {
       // Fire scripts
    }

    public override void HeavyAttack()
    {
        throw new System.NotImplementedException();
    }

    public override void LightAttack()
    {
        throw new System.NotImplementedException();
    }

    public override void SpecialAttack()
    {
        throw new System.NotImplementedException();
    }

}
