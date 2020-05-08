using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public static EnergyBar Instance;

    [SerializeField] private Image _energyBar;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateEnergyBar(float amountOfEnergy)
    {
        _energyBar.fillAmount = amountOfEnergy;
    }
}
