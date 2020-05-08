using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearPlaneStateManager : MonoBehaviour
{
    public static BearPlaneStateManager Instance;

    private PlayerPlane _planeMechanics;
    private BearMechanics _bearMechanics;
    private PlayerCharacter _platformerCharacter;
    private Rigidbody2D _rigidbody2D;

    //SHARED VARIABLES
    private int _health;
    public int maxHealth;
    private float _energy;
    public float maxEnergy;

    //BEAR RIGIDBODY VARIABLES
    public float bearMass;
    public float bearDrag;
    public float bearGravity;

    //PLANE RIGIDBODY VARIABLES
    public float planeMass;
    public float planeDrag;
    public float planeGravity;

    //SPRITES
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Sprite _idle;
    [SerializeField] private Sprite _fly;

    //AUDIO
    [SerializeField] private AudioSource _openWings;
    [SerializeField] private AudioSource _closeWings;

    private bool _isPlane;

    void Awake()
    {
        Instance = this;
        _planeMechanics = GetComponent<PlayerPlane>();
        _bearMechanics = GetComponent<BearMechanics>();
        _platformerCharacter = GetComponent<PlayerCharacter>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _energy = 1;
        _health = maxHealth;
    }

    void Update()
    {
        //DetermineIsPlaneMouse();
        DetermineIsPlaneController();
    }

    void DetermineIsPlaneMouse()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SwitchToPlaneMechanics();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            SwitchToBearMechanics();
        }
    }

    void DetermineIsPlaneController()
    {
        if (Input.GetButtonDown("Jump") && !_platformerCharacter.controller.isGrounded() && !_isPlane)
        {
            SwitchToPlaneMechanics();
        }
        else if (Input.GetButtonUp("Jump") && _isPlane)
        {
            SwitchToBearMechanics();
        }

    }

    void SwitchToBearMechanics()
    {
        _isPlane = false;
        _sprite.sprite = _idle;
        _planeMechanics.enabled = false;
        _bearMechanics.enabled = true;
        _platformerCharacter.enabled = true;
        SetRigidBody(bearMass, bearDrag, bearGravity);
        _closeWings.Play();
    }

    void SwitchToPlaneMechanics()
    {
        //TODO Force fly sprite if pound is still happening
        _isPlane = true;
        _sprite.sprite = _fly;
        _planeMechanics.enabled = true;
        _bearMechanics.enabled = false;
        _platformerCharacter.enabled = false;
        SetRigidBody(planeMass, planeDrag, planeGravity);
        _openWings.Play();
        if (transform.localScale.x == -1)
        {
            GetComponent<CharacterController2D>().Flip();
        }
    }

    void SetRigidBody(float mass, float drag, float gravity)
    {
        _rigidbody2D.mass = mass;
        _rigidbody2D.drag = drag;
        _rigidbody2D.gravityScale = gravity;
    }

    public void AddEnergy(float amountToAdd)
    {
        print("amountToAdd " + amountToAdd);
        _energy += amountToAdd;
        if (_energy > maxEnergy)
        {
            _energy = maxEnergy;
        }
        EnergyBar.Instance.UpdateEnergyBar(_energy);
    }

    public void UseEnergy(float amountToUse)
    {
        _energy -= amountToUse;
        EnergyBar.Instance.UpdateEnergyBar(_energy);
        if (_energy < 0)
        {
            //TODO: Handle running out of energy
            _planeMechanics.Splode();
        }
    }

    public void HandleHit(int damageTaken)
    {
        _health = _health - damageTaken;

        if (_health <= 0)
        {
            _planeMechanics.Splode();
        }

        float healthDecimal = (float)_health / (float)maxHealth;
        HealthBar.Instance.UpdateHealthBar(healthDecimal);
        _planeMechanics.PlayHitSound();
    }
}
