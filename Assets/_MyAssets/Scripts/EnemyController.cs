using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float speed = .7f;
    [SerializeField]
    private Rigidbody2D rigidBody;
    private Vector2 direction = new Vector2(-1, 0);


    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(direction.x * speed, 0);
    }
}
