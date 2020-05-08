using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionShrapnel : MonoBehaviour
{
    [SerializeField] private CircleCollider2D _circleCollider;
    [SerializeField] private int _damageToGive;
    [SerializeField] private float _timeToExist;

    private void Start()
    {
        StartCoroutine(Exist());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Plane>().HandleHit(_damageToGive);
        }

        if (collision.tag == "Player" && collision.gameObject)
        {
            collision.GetComponent<BearPlaneStateManager>().HandleHit(_damageToGive);
        }
    }

    IEnumerator Exist()
    {
        yield return new WaitForSeconds(_timeToExist);
        _circleCollider.enabled = false;
    }
}
