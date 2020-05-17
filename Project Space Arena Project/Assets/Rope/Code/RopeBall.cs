using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyShip>())
        {
            EnemyShip collidingShip = collision.GetComponent<EnemyShip>();
            collidingShip.Splode();
        }

        if (collision.GetComponent<Pilot>())
        {
            Pilot collidingPilot = collision.GetComponent<Pilot>();
            collidingPilot.Splode();
        }
    }
}
