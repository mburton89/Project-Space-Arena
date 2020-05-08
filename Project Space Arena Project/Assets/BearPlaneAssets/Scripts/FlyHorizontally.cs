using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyHorizontally : MonoBehaviour
{
    private Plane _plane;
    [SerializeField] private bool _flyLeft;
    private Vector3 _directionToFly;

    void Awake()
    {
        _plane = GetComponent<Plane>();
    }

    void Start()
    {
        if (_flyLeft)
        {
            _directionToFly = Vector3.left;
        }
        else
        {
            _directionToFly = Vector3.right;
        }
    }

    void Update()
    {
        if (!_plane.isToast)
        {
            _plane.Move(_directionToFly);
        }
    }
}
