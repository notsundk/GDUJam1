using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    public float dmg;
    public float bulletSpeed;

    private void Update()
    {
        //this.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed * Time.deltaTime;
        //print(transform.forward);
    }
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
