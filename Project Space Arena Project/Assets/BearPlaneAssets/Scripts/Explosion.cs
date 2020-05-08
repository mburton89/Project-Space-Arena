using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject _explosionChunkPrefab;
    private AudioSource _audioSource;

    public void Splode()
    {
        ScreenShaker.Instance.ShakeScreen();
        _audioSource.Play();

        for (int i = 0; i < 12; i++)
        {
            Instantiate(_explosionChunkPrefab, this.transform.position, this.transform.rotation, this.transform);
        }

        Destroy(gameObject, 1.5f);
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        Splode();
    }
}
