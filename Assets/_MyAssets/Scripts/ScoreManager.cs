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
            bestScoreText.text = BestScore.ToString();
            scoreText.text = PlayerPrefs.GetInt(BEST_SCORE).ToString();
        }
    }

    private void OnEnable()
    {
        BulletCollisionHandler.OnEnemyDestry += AddPoints;
        PauseManager.OnGameEnd += CheckForNewBestScore;
    }

    private void OnDisable()
    {
        BulletCollisionHandler.OnEnemyDestry -= AddPoints;
        PauseManager.OnGameEnd -= CheckForNewBestScore;
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
        }
    }

    public void CheckForNewBestScore()
    {
        if (Score > bestScore)
        {
            BestScore = Score;
            bestScoreText.text = BestScore.ToString();
            PlayerPrefs.SetInt(BEST_SCORE, bestScore);
        }
        ResetScore();
    }

    private void AddPoints()
    {
        Score += 10;
    }
    private void ResetScore()
    {
        Score = 0;
    }
    public void ResetBestScore()
    {
        PlayerPrefs.DeleteKey(BEST_SCORE);
        BestScore = 0;
        bestScoreText.text = "0";
    }
}
