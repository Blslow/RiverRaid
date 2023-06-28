using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform bulletSpawnPoint;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float speed = 6;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && GameManager.Instance.GameState == GameState.IN_GAME)
        {
            GameObject newBullet = ObjectPooler.GetObject(bulletPrefab);
            newBullet.transform.position = bulletSpawnPoint.position;
            newBullet.name = "Bullet";
            newBullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * speed;
        }
    }
}
