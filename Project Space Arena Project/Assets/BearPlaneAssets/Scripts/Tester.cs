using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    private PlayerCharacter _playerCharacter;

    private void Awake()
    {
        _playerCharacter = FindObjectOfType<PlayerCharacter>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ScreenShaker.Instance.ShakeScreen();
        }

        //if (_playerCharacter.transform.position.y < -20 )
        //{
        //    _playerCharacter.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //    Plane anyPlane = FindObjectOfType<Plane>();
        //    if (anyPlane != null)
        //    {
        //        Vector3 newPos = new Vector3(anyPlane.transform.position.x, anyPlane.transform.position.y + 5, 0);
        //        _playerCharacter.transform.position = newPos;
        //    }
        //}
    }
}
