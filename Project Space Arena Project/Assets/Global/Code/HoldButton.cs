using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonPressed;
    private PlayerShip _playerShip;

    void Start()
    {
        _playerShip = FindObjectOfType<PlayerShip>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }

    void Update()
    {
        if (buttonPressed && _playerShip != null)
        {
            _playerShip.Thrust();
        }
    }
}
