using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private Rigidbody2D rigidBody;
    private Vector2 direction;
    private Transform rootTransform;
    private Health health;

    private void Awake()
    {
        rootTransform = transform.parent.GetComponent<Transform>();
        health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        Timer.OnTimerEnd += MovePlayerToInitialPosition;
        PauseManager.OnGameStart += InitializePlayer;
    }

    private void OnDisable()
    {
        Timer.OnTimerEnd -= MovePlayerToInitialPosition;
        PauseManager.OnGameStart -= InitializePlayer;
    }
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        direction = new Vector2(0, directionY).normalized;
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(0, direction.y * speed);
    }

    public void InitializePlayer()
    {
        rootTransform.position = new Vector2(-2.4f, 0);
        rootTransform.DOMoveX(-1.9f, .3f);
        health.CurrentHealth = health.MaxHealth;
    }

    private void MovePlayerToInitialPosition()
    {
        rootTransform.DOMove(new Vector2(-2.4f, 0), .4f);
    }
}
