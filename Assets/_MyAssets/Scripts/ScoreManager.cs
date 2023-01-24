using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int score = 0;
    [SerializeField]
    private int bestScore = 0;
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private TMP_Text bestScoreText;

    private const string BEST_SCORE = "BEST_SCORE";

    private void Start()
    {
        if (PlayerPrefs.HasKey(BEST_SCORE))
        {
            BestScore = PlayerPrefs.GetInt(BEST_SCORE);
            //Debug.Log(PlayerPrefs.GetInt(BEST_SCORE));
            scoreText.text = PlayerPrefs.GetInt(BEST_SCORE).ToString();
        }
    }

    public int Score
    {
        get => score;
        set
        {
            score = value;
            scoreText.text = score.ToString();
        }
    }

    public int BestScore 
    {
        get => bestScore;
        set
        {
            bestScore = value;
            bestScoreText.text = score.ToString();
        }
    }

    public void CheckForNewBestScore()
    {
        if (Score > bestScore)
        {
            BestScore = Score;
            PlayerPrefs.SetInt(BEST_SCORE, bestScore);
        }
    }
}
