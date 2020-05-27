using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    private Vector2 _phoneMiddle;

    private void Update()
    {
#if UNITY_EDITOR
        //HandleMouseInput();
        HandleControllerInput();
#endif
    }

    void HandleMouseInput()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 directionFacing = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = directionFacing; //Faces Mouse

        if (Input.GetMouseButton(1))
        {
            Thrust();
            rigidBody2D.drag = 0;
        }
        else
        {
            rigidBody2D.drag = friction;
        }

        if (Input.GetMouseButtonDown(0))
        {
            FireProjectile();
        }
    }

    void HandlePhoneInput()
    {
        Vector2 direction = new Vector2(Input.acceleration.x, Input.acceleration.y);
        Vector2 directionRelativeToPhoneMiddle = direction - _phoneMiddle;
        transform.up = directionRelativeToPhoneMiddle;
    }

    public void HandlePhoneInput(Vector2 initialTouchPosition, Vector2 currentTouchPosition)
    {
        Vector2 directionRelativeToPhoneMiddle = currentTouchPosition - initialTouchPosition;
        transform.up = directionRelativeToPhoneMiddle;
    }

    public void HandleControllerInput()
    {
        Vector2 directionFacing = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.up = directionFacing;

        if (Input.GetButtonDown("Attack"))
        {
            FireProjectile();
        }

        float thrustAmount = Input.GetAxis("AttackTrigger");
        print(thrustAmount);
        if (thrustAmount > 0)
        {
            Thrust(thrustAmount);
        }
    }

    public void CalibrateMiddle()
    {
        _phoneMiddle = new Vector2(Input.acceleration.x, Input.acceleration.y);
    }

    public override void HandleDamageTaken()
    {
        HealthBar.Instance.UpdateHealthBar((float)currentArmor / (float)maxArmor);
    }

    public override void HandleDeath()
    {
        SceneController.Instance.RestartScene();
    }
}
