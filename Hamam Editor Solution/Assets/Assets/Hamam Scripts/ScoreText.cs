using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private void OnEnable()
    {
        GameManager.OnScoreChanged += SetScoreText;
    }

    private void OnDisable()
    {
        GameManager.OnScoreChanged -= SetScoreText;
    }

    public void SetScoreText(int score = 0)
    {
        _scoreText.SetText($"Score: {score}");
    }
}