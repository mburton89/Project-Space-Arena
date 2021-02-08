using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeflectionShield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>())
        {
            //DeflectProjectile(collision.GetComponent<Projectile>());
            DumbDeflectProjectile(collision.GetComponent<Projectile>());
        }

        if (collision.GetComponent<EnemyShip>())
        {
            DeflectShip(collision.GetComponent<EnemyShip>());
        }
    }

    void DeflectProjectile(Projectile projectile)
    {
        //find direction between self and projectile
        Vector2 directionToDeflect = (projectile.transform.position - transform.position);

        projectile.firer = null;
        projectile.damageToGive *= 2;
        float projectileMagnitude = projectile.rigidbody2D.velocity.magnitude;
        projectile.rigidbody2D.velocity = Vector2.zero;
        projectile.transform.up = directionToDeflect;

        projectile.rigidbody2D.AddForce((directionToDeflect.normalized * projectileMagnitude) * 2);

        //find owners velocity
        Rigidbody2D parentRigidbody = GetComponentInParent<Rigidbody2D>();
        Vector2 parentVelocity = parentRigidbody.velocity;
        print("parentVelocity" + parentVelocity);
        projectile.rigidbody2D.AddForce(parentVelocity * 2);
    }

    void DumbDeflectProjectile(Projectile projectile)
    {
        projectile.firer = null;
        projectile.damageToGive *= 2;
        projectile.rigidbody2D.velocity = -projectile.rigidbody2D.velocity;
    }

    void DeflectShip(EnemyShip enemyShip)
    {
        //find owners velocity
        Rigidbody2D parentRigidbody = GetComponentInParent<Rigidbody2D>();
        Vector2 parentVelocity = parentRigidbody.velocity;
        print("parentVelocity" + parentVelocity);

        FlyTowardsPlayer flyTowardsPlayer = enemyShip.GetComponent<FlyTowardsPlayer>();
        flyTowardsPlayer.HandleDefected();
        Vector2 enemyShipVelocity = enemyShip.rigidBody2D.velocity;
        print("enemyShipVelocity" + enemyShipVelocity);

        Vector2 netVelocity = parentVelocity - enemyShipVelocity;
        print("netVelocity" + netVelocity);

        enemyShip.rigidBody2D.velocity = Vector2.zero;
        enemyShip.rigidBody2D.AddForce((enemyShipVelocity) + (parentVelocity), ForceMode2D.Impulse);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
