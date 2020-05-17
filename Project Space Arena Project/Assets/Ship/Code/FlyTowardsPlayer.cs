using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTowardsPlayer : MonoBehaviour
{
    private EnemyShip _ownShip;
    private PlayerShip _playerShip;
    [HideInInspector] public bool canFlyTowardsPlayer;

    private void Awake()
    {
        _ownShip = GetComponent<EnemyShip>();
        _playerShip = FindObjectOfType<PlayerShip>();
        canFlyTowardsPlayer = true;
    }

    void Update()
    {
        if (_playerShip == null) return;
        if (canFlyTowardsPlayer)
        {
            Vector2 directionFacing = new Vector2(_playerShip.transform.position.x - transform.position.x, _playerShip.transform.position.y - transform.position.y);
            transform.up = directionFacing;
            _ownShip.Thrust();
        }
    }
}
