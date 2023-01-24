using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float timeForEachGame = 10;
    private float timeLeft;
    [SerializeField]
    private bool timerOn = false;
    [SerializeField]
    private TMP_Text timerText;

    public float TimeForEachGame { get => timeForEachGame; set => timeForEachGame = value; }
    public float TimeLeft { get => timeLeft; set => timeLeft = value; }

    private void Start()
    {
        timerOn = true;
        timeLeft = timeForEachGame;
    }

    private void Update()
    {
        if (timerOn & timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            updateTimer(timeLeft);
        }
        else
        {
            //timeLeft = timeForEachGame;
            //timerOn = false;
            GameManager.Instance.EndGame();
        }
    }

    private void updateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
