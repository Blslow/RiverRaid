using System;
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

    public static event Action OnTimerEnd;


    private void OnEnable()
    {
        PauseManager.OnGameStart += StartTimer;
        Health.OnPlayerDeath += ForceStopTimer;
    }

    private void OnDisable()
    {
        PauseManager.OnGameStart -= StartTimer;
        Health.OnPlayerDeath -= ForceStopTimer;
    }

    private void Update()
    {
        if (!timerOn)
            return;

        if (timerOn & timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimer(timeLeft);
        }
        else
        {
            StopTimer();
        }
    }

    private void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    private void StartTimer()
    {
        timerOn = true;
        timeLeft = timeForEachGame;
    }
    private void StopTimer()
    {
        OnTimerEnd?.Invoke();
        timerOn = false;
        timeLeft = timeForEachGame;
    }
    private void ForceStopTimer()
    {
        timerOn = false;
        timeLeft = timeForEachGame;
    }
}
