using UnityEngine;
using TMPro;

public class PointsCounter : MonoBehaviour
{
    public static PointsCounter Instance;
    private int _points;
    private TextMeshProUGUI _text;

    void Awake()
    {
        Instance = this;
        _points = 0;
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void IncreasePoints(int amount)
    {
        _points = _points + amount;
        _text.SetText(_points.ToString());
    }
}
