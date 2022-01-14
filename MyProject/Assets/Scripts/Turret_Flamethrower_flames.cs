using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Flamethrower_flames : MonoBehaviour
{
    public float dmg;
    public float bulletSpeed;
    public float lifespan;
    private float timer;

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if(timer > lifespan)
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
        }
    }
}
