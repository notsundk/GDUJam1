using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Laser : MonoBehaviour
{
    public float dmg;
    public float lifeSpan;
    private float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        if(lifeSpan < timer)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject enemy = collision.gameObject;
        if(enemy.CompareTag("enemy"))
        {
            enemy.GetComponent<Enemy>().hp -= dmg;
            enemy.GetComponent<Enemy>().slowed = true;
        }
    }
}
