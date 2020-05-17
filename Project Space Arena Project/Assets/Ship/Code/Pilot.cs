using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot : MonoBehaviour
{
    [SerializeField] private GameObject _bloodPrefab;
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2d;
    private BoxCollider2D _boxCollider;
    private float _rotationAmount;

    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rotationAmount = Random.Range(-12f, 12f);
        float _flingSpeed = Random.Range(5f, 15f);
        Vector2 _flingDirection = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));
        _rigidbody2d.AddForce(_flingDirection.normalized * _flingSpeed);
        StartCoroutine(Animate());
    }

    void Update()
    {
        _rigidbody2d.rotation += _rotationAmount;
    }

    public void Splode()
    {
        Instantiate(_bloodPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private IEnumerator Animate()
    {
        yield return new WaitForSeconds(.25f);
        _boxCollider.enabled = true;
        if (_spriteRenderer.sprite == sprite1)
        {
            _spriteRenderer.sprite = sprite2;
        }
        else
        {
            _spriteRenderer.sprite = sprite1;
        }
        StartCoroutine(Animate());
    }
}
