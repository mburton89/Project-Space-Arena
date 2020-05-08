using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    private Plane _plane;
    private BearPlaneStateManager _player;
    private float _distanceToPlayer;
    private Vector3 _heading;
    private Vector3 _positionToFireTowards;

    void Awake()
    {
        _plane = GetComponent<Plane>();
        _player = FindObjectOfType<BearPlaneStateManager>();
    }

    void Update()
    {
        if (_player == null) return;
        _positionToFireTowards = _player.transform.position;
        _heading = _positionToFireTowards - transform.position;
        _distanceToPlayer = _heading.magnitude;
        if (_distanceToPlayer > 1.5f && _distanceToPlayer < _plane.sightDistance && _plane.hasPilot && !_plane.isToast && _plane.canShoot)
        {
            _plane.FireProjectile(new Vector2(_heading.x, _heading.y));
        }
    }
}
