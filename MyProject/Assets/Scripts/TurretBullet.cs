using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    public int dmg;
    public float bulletSpeed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject enemy = collision.gameObject;
        if (enemy.CompareTag("enemy"))
        {
            enemy.GetComponent<Enemy>().hp -= dmg;
            Destroy(gameObject);
        }
    }
}
