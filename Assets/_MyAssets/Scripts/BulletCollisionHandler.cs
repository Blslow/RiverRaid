using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    public static event Action OnEnemyDestry;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6) // 6 is Enemy layer
        {
            //GameManager.Instance.Scripts.GetComponent<ScoreManager>().Score += 10;
            OnEnemyDestry?.Invoke();
        }
        ObjectPooler.ReturnGameObject(gameObject);
    }
}
