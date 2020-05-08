using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : Plane
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Plane>().Splode();
            GetComponent<Plane>().Splode();
        }
    }

    //public override void Move(Vector2 force)
    //{
    //    throw new System.NotImplementedException();
    //}
}
