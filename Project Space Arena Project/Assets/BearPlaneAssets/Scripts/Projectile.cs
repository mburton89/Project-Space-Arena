using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    [HideInInspector] public GameObject firer;
    public int damageToGive;

    public void Init(GameObject firer)
    {
        this.firer = firer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ship>() && collision.gameObject != firer)
        {
            collision.GetComponent<Ship>().ApplyDamage(damageToGive);
            Destroy(gameObject);
        }

        if (collision.GetComponent<Pilot>())
        {
            Pilot collidingPilot = collision.GetComponent<Pilot>();
            collidingPilot.Splode();
        }
    }

    public abstract void Splode();
}
