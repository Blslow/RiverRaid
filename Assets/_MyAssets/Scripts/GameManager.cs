using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("References")]
    [SerializeField]
    private GameObject player;

    [Header("Prefabs")]
    [SerializeField]
    private GameObject playerPrefab;

    [Header("Game State")]
    public GameState GameState = GameState.GAME_OVER;

    public static GameManager Instance;

    public GameObject Player { get => player; }
    public GameObject PlayerPrefab { get => playerPrefab; }

    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitPlayer();
    }

    private void InitPlayer()
    {
        if (!player || !player.activeSelf)
        {
            player = ObjectPooler.GetObject(playerPrefab);
            player.name = "Player";
        }
    }
}


public enum GameState
{
    GAME_OVER,
    IN_GAME,
}