using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAI : MonoBehaviour
{
    private Plane _plane;
    private float _distanceToPosition = 0;
    private Vector3 _heading;
    public Vector3 positionToMoveTo;
    private bool _isInPosition = false;
    private BearPlaneStateManager _player;

    public enum MovementType {moveToPosition, moveTowardsPlayer, moveLeft, moveRight }
    public MovementType currentMovementType;

    private void Awake()
    {
        _plane = GetComponent<Plane>();
        _player = FindObjectOfType<BearPlaneStateManager>();
    }

    private void Start()
    {
        MoveToPosition();
    }

    private void Update()
    {
        if (currentMovementType == MovementType.moveLeft || currentMovementType == MovementType.moveRight)
        {
            MoveToPosition();
            return;
        }

        if (currentMovementType == MovementType.moveTowardsPlayer && _player != null)
        {
            positionToMoveTo = _player.transform.position;
        }

        _heading = positionToMoveTo - transform.position;
        _distanceToPosition = _heading.magnitude;
        if (_distanceToPosition > 0.5f && _plane.hasPilot && !_plane.isToast)
        {
            MoveToPosition();
        }
    }

    public void MoveRight()
    {
        _plane.Move(Vector2.right);
    }

    public void MoveToPosition()
    {
        Vector3 direction = (_heading).normalized;
        Vector2 DirectionToMove = new Vector2(direction.x, direction.y);
        _plane.Move(DirectionToMove);
    }

    public void MoveToPlayer()
    {
        Vector3 direction = (_heading).normalized;
        Vector2 DirectionToMove = new Vector2(direction.x, direction.y);
        _plane.Move(DirectionToMove);
    }
}
