using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Image image;

    private void FixedUpdate()
    {
        if (transform.localPosition.x <= -image.preferredWidth)
        {
            transform.localPosition = Vector2.zero;
        }
        transform.position = new Vector2(transform.position.x - Mathf.Abs(speed) * Time.deltaTime, transform.position.y);
    }
}
