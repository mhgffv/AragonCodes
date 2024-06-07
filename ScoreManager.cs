using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    int Score;
    TMP_Text scoreText;
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Score:";
    }

    public void plusScore(int scoreAmount)
    {
        Score += scoreAmount;
        scoreText.text = $"Score: {Score}";
    }
}

