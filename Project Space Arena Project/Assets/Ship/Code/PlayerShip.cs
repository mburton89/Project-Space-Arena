using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    private void Update()
    {
#if UNITY_EDITOR
        FaceMouse();

        if (Input.GetMouseButton(1))
        {
            MoveInDirection(transform.up);
            rigidBody2D.drag = 0;
        }
        else
        {
            rigidBody2D.drag = friction;
        }

        if (Input.GetMouseButtonDown(0))
        {
            FireProjectile();
        }
#endif
    }

    void FixedUpdate()
    {
        if (rigidBody2D.velocity.magnitude > maxSpeed)
        {
            rigidBody2D.velocity = rigidBody2D.velocity.normalized * maxSpeed;
        }
    }

    void FireProjectile()
    {
        print("PEW PEW!");
    }

    void FaceMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }
}
