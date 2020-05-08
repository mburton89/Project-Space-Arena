using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearClaws : MonoBehaviour
{
    private BearMechanics _controller;
    public float energyConsumptionAmount;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private AudioSource _audioSource;
    public int damageToGive;

    public void Init(BearMechanics controller)
    {
        _controller = controller;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Plane plane = collision.GetComponent<Plane>();
            plane.HandleHit(damageToGive);
            _audioSource.Play();
            ScreenShaker.Instance.ShakeScreen(0.1f, 0.2f);
            if (plane.hasPilot)
            {
                _controller.ThrowPilot();
                plane.hasPilot = false;
            }
        }
    }

    public void Attack()
    {
        _collider.enabled = true;
    }

    public void FinishAttack()
    {
        _collider.enabled = false;
    }
}
