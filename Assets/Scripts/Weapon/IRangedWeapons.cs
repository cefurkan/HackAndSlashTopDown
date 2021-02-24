using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRangedWeapons
{
     GameObject Projectile { get; set; }

     void Fire();
}
