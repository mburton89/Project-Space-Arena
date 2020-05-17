using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeflectionShieldController : MonoBehaviour
{
    [SerializeField] private Ship _controller;
    [SerializeField] private float _secondsToExist;
    [SerializeField] private float _secondsForCooldown;
    [SerializeField] DeflectionShield _deflectionShield;
    private bool _canDeflect;

    private void Start()
    {
        _canDeflect = true;
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Deflect();
        }
    }
#endif

    public void Deflect()
    {
        if (_canDeflect)
        {
            StartCoroutine(DeflectCo());
        }
    }

    private IEnumerator DeflectCo()
    {
        _canDeflect = false;
        _deflectionShield.Activate();
        _controller.canTakeDamage = false;
        yield return new WaitForSeconds(_secondsToExist);
        _deflectionShield.Deactivate();
        _controller.canTakeDamage = true;
        yield return new WaitForSeconds(_secondsForCooldown);
        _canDeflect = true;
    }
}
