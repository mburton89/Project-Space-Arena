using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;
    public int maxArmor;
    public float projectileSpeed;
    public float fireRate;
    public float friction;

    public GameObject thrustParticlePrefab;
    public Transform particleSpawnPoint;
    public Transform particleParent;

    [HideInInspector] public Rigidbody2D rigidBody2D;
    [HideInInspector] public Vector3 heading;

    public void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void MoveInDirection(Vector2 direction)
    {
        rigidBody2D.AddForce(direction * acceleration);
        CreateThrustParticles();
    }

    public void MoveToPosition(Vector3 newHeading)
    {
        Vector3 direction = (newHeading).normalized;
        Vector2 DirectionToMove = new Vector2(direction.x, direction.y);
        Vector2 DirectionToMoveNormalized = DirectionToMove.normalized;
        MoveInDirection(DirectionToMoveNormalized);
    }

    public void CreateThrustParticles()
    {
        GameObject thrustParticle = Instantiate(thrustParticlePrefab, particleSpawnPoint.position, transform.rotation, particleParent);
    }
}
