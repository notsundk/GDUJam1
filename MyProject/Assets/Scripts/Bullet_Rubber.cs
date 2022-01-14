using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Rubber : MonoBehaviour
{
    public float knockForce;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject enemy = collision.gameObject;
        if(enemy.CompareTag("enemy"))
        {
            Vector2 force = transform.position - enemy.transform.position;
            force.Normalize();
            force *= knockForce;
            enemy.GetComponent<Enemy>().stunned = true;
            enemy.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            enemy.GetComponent<Rigidbody2D>().AddForce(-force);
            Destroy(gameObject);
        }
    }
}
