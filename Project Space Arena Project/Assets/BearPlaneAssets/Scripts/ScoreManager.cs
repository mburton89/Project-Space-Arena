using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [HideInInspector] public float score;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Awake()
    {
        Instance = this;
    }

    public void IncrementScore()
    {
        score++;
        _scoreText.SetText(score.ToString());
    }
}
