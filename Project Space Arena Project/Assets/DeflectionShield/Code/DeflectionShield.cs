using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeflectionShield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>())
        {
            DeflectProjectile(collision.GetComponent<Projectile>());
        }

        if (collision.GetComponent<EnemyShip>())
        {
            DeflectShip(collision.GetComponent<EnemyShip>());
        }
    }

    void DeflectProjectile(Projectile projectile)
    {
        projectile.firer = null;
        projectile.damageToGive *= 2;
        Vector2 currentVelocity = projectile.rigidbody2D.velocity;
        projectile.rigidbody2D.velocity = Vector2.zero;
        projectile.rigidbody2D.AddForce(-currentVelocity * 2);
    }

    void DeflectShip(EnemyShip enemyShip)
    {
        StartCoroutine(DeflectShipCo(enemyShip));
    }

    private IEnumerator DeflectShipCo(EnemyShip enemyShip)
    {
        Vector2 currentVelocity = enemyShip.rigidBody2D.velocity;
        enemyShip.rigidBody2D.velocity = Vector2.zero;
        enemyShip.rigidBody2D.AddForce(-currentVelocity * 1000);
        enemyShip.GetComponent<FlyTowardsPlayer>().canFlyTowardsPlayer = false;
        yield return new WaitForSeconds(1);
        enemyShip.GetComponent<FlyTowardsPlayer>().canFlyTowardsPlayer = true;
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
