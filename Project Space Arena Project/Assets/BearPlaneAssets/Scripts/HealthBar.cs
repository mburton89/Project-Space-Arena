using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar Instance;

    [SerializeField] private Image _healthBarFill;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateHealthBar(float amountOfHealth)
    {
        _healthBarFill.fillAmount = amountOfHealth;
    }
}
