using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float transitionTime = 0.45f;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.anyKeyDown && Time.timeScale == 0)
        {
            StartCoroutine(CrossFadeStart());
            GameManager.Instance.Player.GetComponentInChildren<Health>().CurrentHealth = 3;
            GameManager.Instance.Player.transform.position = GameManager.Instance.PlayerPrefab.transform.position;
            GameManager.Instance.Scripts.GetComponent<ScoreManager>().Score = 0;
            //GameManager.Instance.Scripts.GetComponent<EnemySpawner>().DestroyAllEnemies();

            // todo?: change all GameManager.Instace to events or something
        }
    }

    public void TogglePause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            GameManager.Instance.GameState = GameState.IN_GAME;
        }
        else
        {
            Time.timeScale = 0;
            GameManager.Instance.GameState = GameState.GAME_OVER;
        }
    }

    private IEnumerator CrossFadeStart()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(transitionTime);
        TogglePause();
    }

    public IEnumerator CrossFadeEnd()
    {
        TogglePause();
        animator.SetTrigger("End");
        yield return new WaitForSecondsRealtime(transitionTime);
    }
}
