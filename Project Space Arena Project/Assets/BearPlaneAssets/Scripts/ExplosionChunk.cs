using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionChunk : MonoBehaviour
{
    int speed;
    float duration;
    float _x;
    float _y;

    [SerializeField] private int _intensity;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private GameObject _explosionParticlePrefab;

    void Start()
    {
        _x = Random.Range(-1.0f, 1.0f);
        _y = Random.Range(-1.0f, 1.0f);
        speed = Random.Range(_intensity , _intensity * 2);
        duration = Random.Range(0.3f, 1.0f);
        Destroy(gameObject, duration);
        _rigidbody2D.AddForce(new Vector2(_x, _y) * speed);
    }

    void Update()
    {
        float newX = transform.position.x + Random.Range(-0.4f, 0.4f);
        float newY = transform.position.y + Random.Range(-0.4f, 0.4f);
        Vector3 newPosition = new Vector3(newX, newY, 0);
        GameObject explosionParticle = Instantiate(_explosionParticlePrefab, newPosition, this.transform.rotation, this.transform);
    }
}
