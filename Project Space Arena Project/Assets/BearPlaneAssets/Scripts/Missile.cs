using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Projectile
{
    [SerializeField] private float _acceleration;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _secondsBeforeSplode;
    [SerializeField] private Explosion _explosionPrefab;
    private Vector3 _heading;
    private Vector3 _positionToMoveTo;
    private BearPlaneStateManager _player;

    private void Awake()
    {
        _player = FindObjectOfType<BearPlaneStateManager>();
    }

    private void Start()
    {
        Destroy(gameObject, _secondsBeforeSplode);
    }

    private void OnDestroy()
    {
        Splode();
    }

    public override void Splode()
    {
        Instantiate(_explosionPrefab, this.transform.position, this.transform.rotation);
    }

    private void Update()
    {
        if (_player != null)
        {
            _positionToMoveTo = _player.transform.position;
        }

        _heading = _positionToMoveTo - transform.position;
        Vector3 direction = (_heading).normalized;
        Vector2 DirectionToMove = new Vector2(direction.x, direction.y);
        rigidbody2D.AddForce(direction * _acceleration);
    }

    void FixedUpdate()
    {
        if (rigidbody2D.velocity.magnitude > _maxSpeed)
        {
            rigidbody2D.velocity = rigidbody2D.velocity.normalized * _maxSpeed;
        }
    }
}
