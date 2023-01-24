using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) // 3 is a player layer
            GameManager.Instance.Player.GetComponentInChildren<Health>().GetHit();

        ObjectPooler.ReturnGameObject(transform.parent.gameObject);
        //Debug.Log(collision.name);
    }
}
