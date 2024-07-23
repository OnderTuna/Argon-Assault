using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    float score = 0f;

    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void ScoreCalculator(float _score)
    {
        score += _score;
        scoreText.text = score.ToString();
    }
}
