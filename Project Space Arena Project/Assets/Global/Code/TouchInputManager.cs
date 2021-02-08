using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInputManager : MonoBehaviour
{
    private PlayerShip _playerShip;
    private DeflectionShieldController _deflectionShieldController;
    [SerializeField] private Button _cameraFollowButton;
    [SerializeField] private HoldButton _thrustButton;
    [SerializeField] private HoldButton _fireProjectileButton;
    [SerializeField] private HoldButton _deflectShieldButton;
    [SerializeField] private GameObject _touchCircle;
    [SerializeField] private FollowPlayer _cameraFollow;
    private Vector2 _initialTouchPosition;
    private Vector2 _currentTouchPosition;
       
    void Start()
    {
        _playerShip = FindObjectOfType<PlayerShip>();
        _deflectionShieldController = FindObjectOfType<DeflectionShieldController>();
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

        if (_thrustButton.isPressed && _playerShip != null)
        {
            _playerShip.Thrust();
        }
    }

    private void OnEnable()
    {
        _cameraFollowButton.onClick.AddListener(ToggleCameraFollow);
        _fireProjectileButton.onPointerDown.AddListener(FireProjectile);
        _deflectShieldButton.onPointerDown.AddListener(DeployDefectShield);
    }

    private void OnDisable()
    {
        _cameraFollowButton.onClick.RemoveListener(ToggleCameraFollow);
        if (_playerShip != null)
        {
            _fireProjectileButton.onPointerDown.RemoveListener(_playerShip.FireProjectile);
        }
        _deflectShieldButton.onPointerDown.RemoveListener(DeployDefectShield);
    }

    void FireProjectile()
    {
        _playerShip.FireProjectile();
    }

    void DeployDefectShield()
    {
        if (_deflectionShieldController != null)
        {
            _deflectionShieldController.Deflect();
        }
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
