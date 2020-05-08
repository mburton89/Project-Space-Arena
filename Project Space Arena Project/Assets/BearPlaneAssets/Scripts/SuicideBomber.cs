using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuicideBomber : MonoBehaviour
{
    private Plane _plane;
    [SerializeField] private Image _flashyLight;
    [SerializeField] private int _secondsBeforeSplode;
    [SerializeField] private float _secondsBetweenBeeps;
    [SerializeField] private float _secondsBetweenBeepsQuickener;
    [SerializeField] private AudioSource _beep;

    private void Awake()
    {
        _plane = GetComponent<Plane>();
    }

    void Start()
    {
        StartCoroutine(Countdown());
        //StartCoroutine(Beep());
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(_secondsBeforeSplode);
        _plane.Splode();
    }

    IEnumerator Beep()
    {
        _beep.Play();
        yield return new WaitForSeconds(_secondsBetweenBeeps);
        _secondsBetweenBeeps = _secondsBetweenBeeps * _secondsBetweenBeepsQuickener;
        if (_secondsBetweenBeeps < 0.125f)
        {
            _secondsBetweenBeeps = 0.125f;
        }
        StartCoroutine(Beep());
    }
}
