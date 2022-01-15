using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float dmg;
    public float bulletSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("turret"))
        {
            obj.GetComponent<Turret>().hp -= dmg;
            Destroy(gameObject);
        }
        else if(obj.CompareTag("spaceship"))
        {
            obj.GetComponent<SpaceShip>().hp -= dmg;
            Destroy(gameObject);
        }
    }
}
