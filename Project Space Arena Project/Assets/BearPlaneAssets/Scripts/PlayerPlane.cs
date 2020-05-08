using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerPlane : Plane
{
    public float flyingEnergyConsumptionRate;
    public float shootingEnergyConsumptionRate;

    private bool _canFire;
    private float _shouldFire;

    private void Awake()
    {
        base.Awake();
        _canFire = true;
    }

    private void Update()
    {
        BearPlaneStateManager.Instance.UseEnergy(flyingEnergyConsumptionRate);

        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Move(direction);

        if (Input.GetButtonDown("Attack"))
        {
            FireProjectile(Vector2.right);
            BearPlaneStateManager.Instance.UseEnergy(shootingEnergyConsumptionRate);
        }
        DetermineAttackController();

        CreateThrustParticles();
    }

    void DetermineAttackController()
    {
        _shouldFire = Input.GetAxis("AttackTrigger");

        if (_shouldFire == 1 && _canFire)
        {
            FireProjectile(Vector2.right);
            BearPlaneStateManager.Instance.UseEnergy(shootingEnergyConsumptionRate);
            StartCoroutine(FireBuffer());
        }
    }

    IEnumerator FireBuffer()
    {
        _canFire = false;
        yield return new WaitForSeconds(fireRate);
        _canFire = true;
    }
}
