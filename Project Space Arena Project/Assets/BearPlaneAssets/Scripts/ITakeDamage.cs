using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITakeDamage
{
    public float health;

    public void InflictDamage(int damageAmount)
    {
        health = health - damageAmount;
        Debug.Log("health " + health);
    }
}
