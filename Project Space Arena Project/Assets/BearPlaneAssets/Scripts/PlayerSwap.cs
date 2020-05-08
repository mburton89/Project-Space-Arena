using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSwap : MonoBehaviour
{
    public static PlayerSwap Instance;
    public static bool isPlane;
    [SerializeField] private KeyCode _playerToggle;
    [SerializeField] private TextMeshProUGUI _playerLabel;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(_playerToggle))
        {
            isPlane = !isPlane;
            if (isPlane)
            {
                _playerLabel.SetText("PLANE");
            }
            else
            {
                _playerLabel.SetText("BEAR");
            }
        }
    }

    public void SetIsPlane(bool plane)
    {
        isPlane = plane;
    }
}
