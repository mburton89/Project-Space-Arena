using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustParticle : MonoBehaviour
{
    private float _fadeSpeed;
    private float _scale;
    [SerializeField] private SpriteRenderer _sprite;

    private void Start()
    {
        _fadeSpeed = Random.Range(0.075f, 0.15f);
        _scale = Random.Range(0.25f, 1f);
    }

    void Update()
    {
        if (_sprite.color.a > 0)
        {
            float newAlpha = _sprite.color.a - _fadeSpeed;
            _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, newAlpha);
            transform.Translate((Vector3.down * 5) * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
