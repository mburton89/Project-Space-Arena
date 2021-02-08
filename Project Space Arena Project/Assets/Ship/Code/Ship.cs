using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : MonoBehaviour
{
    public float acceleration;
    private float _initialMaxSpeed;
    public float maxSpeed;
    public int maxArmor;
    public float secondsBeforeCanTakeDamage;
    public float secondsBeforeCanThrust;
    public float projectileSpeed;
    public float fireRate;
    public float friction;
    [HideInInspector] public int currentArmor;

    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private Pilot _pilotPrefab;
    [SerializeField] private ThrustParticle _fireParticlePrefab;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private AudioSource _projectileAudioSource;
    [SerializeField] private AudioSource _hitAudioSource;
    public GameObject thrustParticlePrefab;
    public Transform particleSpawnPoint;
    [HideInInspector] public Rigidbody2D rigidBody2D;
    [HideInInspector] public bool canShoot;
    [HideInInspector] public bool canThrust;
    [HideInInspector] public bool canTakeDamage;

    public void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        currentArmor = maxArmor;
        canShoot = true;
        canThrust = true;
        canTakeDamage = true;
        _initialMaxSpeed = maxSpeed;
    }

    void FixedUpdate()
    {
        if (rigidBody2D.velocity.magnitude > (maxSpeed))
        {
            rigidBody2D.velocity = rigidBody2D.velocity.normalized * (maxSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ship>())
        {
            BounceOffShip(collision.gameObject.GetComponent<Ship>());
        }

        if (collision.gameObject.GetComponent<Pilot>())
        {
            Pilot collidingPilot = collision.gameObject.GetComponent<Pilot>();
            collidingPilot.Splode();
        }
    }

    public void Thrust()
    {
        if (canThrust)
        {
            MoveInDirection(transform.up);
            CreateThrustParticles();
        }
    }

    public void Thrust(float amount)
    {
        if (canThrust)
        {
            MoveInDirection(transform.up);
            CreateThrustParticles();
            maxSpeed = _initialMaxSpeed * amount;
        }
    }

    public void MoveInDirection(Vector2 direction)
    {
        rigidBody2D.AddForce(direction * acceleration);
    }

    public void MoveToPosition(Vector3 positionToMoveTo)
    {
        Vector3 heading = positionToMoveTo - transform.position;
        Vector3 direction = (heading).normalized;
        MoveInDirection(direction);
    }

    public void FireProjectile()
    {
        Projectile projectile = Instantiate(_projectilePrefab, _projectileSpawnPoint.position, transform.rotation);
        projectile.Init(this.gameObject);
        projectile.rigidbody2D.AddForce(transform.up * projectileSpeed);
        Instantiate(_fireParticlePrefab, _projectileSpawnPoint.position, transform.rotation);
        _projectileAudioSource.Play();
        StartCoroutine(fireRateBuffer());
    }

    public void CreateThrustParticles()
    {
        float randomX = Random.Range(-0.03f, 0.03f);
        float randomY = Random.Range(-0.03f, 0.03f);
        Vector3 spawnPosition = new Vector3(particleSpawnPoint.position.x + randomX, particleSpawnPoint.position.y + randomY);
        GameObject thrustParticle = Instantiate(thrustParticlePrefab, spawnPosition, transform.rotation);
    }

    public void Splode()
    {
        currentArmor = 0;
        LaunchPilot();
        Instantiate(_explosionPrefab, this.transform.position, this.transform.rotation);
        Destroy(gameObject);
        HandleDamageTaken();
        HandleDeath();
    }

    public abstract void HandleDeath();

    public void ApplyDamage(int damageTaken)
    {
        if (canTakeDamage)
        {
            currentArmor = currentArmor - damageTaken;

            if (currentArmor > 0)
            {
                _hitAudioSource.Play();
            }
            else
            {
                Splode();
            }

            HandleDamageTaken();
        }
    }

    public abstract void HandleDamageTaken();

    void LaunchPilot()
    {
        Pilot pilot = Instantiate(_pilotPrefab, transform.position, transform.rotation);
    }

    IEnumerator fireRateBuffer()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    public void BounceOffShip(Ship shipToBounceOffOf)
    {
        if (GetComponent<EnemyShip>() && canThrust)
        {
            StartCoroutine(ThrustBuffer());
        }

        Vector2 directionToBounce = (transform.position - shipToBounceOffOf.transform.position);
        rigidBody2D.AddForce(directionToBounce.normalized * (shipToBounceOffOf.rigidBody2D.velocity.magnitude * 100));
        ApplyDamage(1);

        if (canTakeDamage)
        {
            StartCoroutine(DamageBuffer());
        }
    }

    private IEnumerator DamageBuffer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(secondsBeforeCanTakeDamage);
        canTakeDamage = true;
    }

    private IEnumerator ThrustBuffer()
    {
        canThrust = false;
        yield return new WaitForSeconds(secondsBeforeCanThrust);
        canThrust = true;
    }
}
