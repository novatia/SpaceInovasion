using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile 
{
    public float Speed;
    public float TimeToLive;

    public abstract void GetEffect(GameObject affected);
    public abstract IEnumerator ProjectileMovement();
}
