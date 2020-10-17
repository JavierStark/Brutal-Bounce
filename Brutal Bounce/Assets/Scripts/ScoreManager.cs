using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int score;

    TMP_Text scoreText;

    private void Awake() {
        scoreText = GetComponent<TMP_Text>();
    }

    public void AddScore() {
        score++;
        UpdateScoreText();
    }

    public void AddScore(int n) {
        score += n;
        UpdateScoreText();
    }

    private void UpdateScoreText() {
        scoreText.text = score.ToString();
    }
}
