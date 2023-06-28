using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private float fadeTime = 0.4f;

    public static event Action OnGameStart;
    public static event Action OnGameEnd;


    private void Start()
    {
        FadeIn();
    }

    private void OnEnable()
    {
        Health.OnPlayerDeath += StartEndGameCoroutine;
        Timer.OnTimerEnd += StartEndGameCoroutine;

    }
    private void OnDisable()
    {
        Health.OnPlayerDeath -= StartEndGameCoroutine;
        Timer.OnTimerEnd -= StartEndGameCoroutine;
    }

    private void Update()
    {
        if (Input.anyKeyDown && GameManager.Instance.GameState == GameState.GAME_OVER)
        {
            StartCoroutine(StartGame());
        }
    }

    private IEnumerator StartGame()
    {
        OnGameStart?.Invoke();
        FadeOut();
        GameManager.Instance.GameState = GameState.IN_GAME;
        yield return new WaitForSeconds(fadeTime);
        EnemySpawner.ShouldEnemiesSpawn = true;
    }
    private void StartEndGameCoroutine()
    {
        StartCoroutine(EndGame());
    }
    private IEnumerator EndGame()
    {
        OnGameEnd?.Invoke();
        FadeIn();
        EnemySpawner.ShouldEnemiesSpawn = false;
        yield return new WaitForSeconds(fadeTime);
        GameManager.Instance.GameState = GameState.GAME_OVER;
    }

    private void FadeIn()
    {
        Debug.Log("FadeIn");
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, fadeTime);
    }

    private void FadeOut()
    {
        canvasGroup.alpha = 1;
        canvasGroup.DOFade(0, fadeTime);
    }
}
