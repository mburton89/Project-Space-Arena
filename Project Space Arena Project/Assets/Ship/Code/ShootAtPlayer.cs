using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{
    private EnemyShip _ownShip;
    private PlayerShip _playerShip;

    void Awake()
    {
        _ownShip = GetComponent<EnemyShip>();
        _playerShip = FindObjectOfType<PlayerShip>();
    }

    void Update()
    {
        if (_playerShip == null) return;
        if (_ownShip.canShoot)
        {
            _ownShip.FireProjectile();
        }
    }
}
