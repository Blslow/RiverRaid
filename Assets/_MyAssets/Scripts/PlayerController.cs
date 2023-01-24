using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private Rigidbody2D rigidBody;
    private Vector2 direction;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        direction = new Vector2(0, directionY).normalized;
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(0, direction.y * speed);
    }
}
