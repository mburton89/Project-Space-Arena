using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    public override void Splode()
    {
        //TODO lil baby splosion
    }

    private void OnDestroy()
    {
        Splode();
    }
}
