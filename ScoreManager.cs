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
        Debug.Log(Score);
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Start";
    }

    void Update()
    {

    }

    public void plusScore(int scoreAmount)
    {
        Score += scoreAmount;
        Debug.Log(Score);
        scoreText.text = $"Score: {Score}";
    }
}

