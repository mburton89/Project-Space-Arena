using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInputManager : MonoBehaviour
{
    private PlayerShip _playerShip;
    [SerializeField] private Button _cameraFollowButton;
    [SerializeField] private Button _fireProjectileButton;
    [SerializeField] private GameObject _touchCircle;
    [SerializeField] private FollowPlayer _cameraFollow;
    private Vector2 _initialTouchPosition;
    private Vector2 _currentTouchPosition;
       
    void Start()
    {
        _playerShip = FindObjectOfType<PlayerShip>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _initialTouchPosition = touch.position;
                _touchCircle.transform.position = _initialTouchPosition;
                _touchCircle.SetActive(true);
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                _currentTouchPosition = touch.position;
            }

            if (_playerShip != null)
            {
                _playerShip.HandlePhoneInput(_initialTouchPosition, _currentTouchPosition);
            }
        }
        else
        {
            _touchCircle.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _fireProjectileButton.onClick.AddListener(FireProjectile);
        _cameraFollowButton.onClick.AddListener(ToggleCameraFollow);
    }

    private void OnDisable()
    {
        if (_playerShip != null)
        {
            _fireProjectileButton.onClick.RemoveListener(_playerShip.FireProjectile);
        }
        _cameraFollowButton.onClick.RemoveListener(ToggleCameraFollow);
    }

    void FireProjectile()
    {
        _playerShip.FireProjectile();
    }

    void HandleLeftSidePressed()
    {
        _playerShip.Thrust();
    }

    void ToggleCameraFollow()
    {
        if (_cameraFollow.enabled)
        {
            _cameraFollow.enabled = false;
        }
        else
        {
            _cameraFollow.enabled = true;
        }
    }
}
