using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOffEdge : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    private Vector3 _prevPosition;

    void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        Vector3 tmpPos = Camera.main.WorldToScreenPoint(transform.position);

        if (tmpPos.x < 0)
        {
            transform.position = _prevPosition;
            _rigidBody2D.velocity = new Vector2(-_rigidBody2D.velocity.x, _rigidBody2D.velocity.y);
        }
        else if (tmpPos.x > Screen.width)
        {
            transform.position = _prevPosition;
            _rigidBody2D.velocity = new Vector2(-_rigidBody2D.velocity.x, _rigidBody2D.velocity.y);
        }
        else if (tmpPos.y < 0)
        {
            transform.position = _prevPosition;
            _rigidBody2D.velocity = new Vector2(_rigidBody2D.velocity.x, -_rigidBody2D.velocity.y);
        }
        else if (tmpPos.y > Screen.height)
        {
            transform.position = _prevPosition;
            _rigidBody2D.velocity = new Vector2(_rigidBody2D.velocity.x, -_rigidBody2D.velocity.y);
        }

        _prevPosition = transform.position;
    }
}
