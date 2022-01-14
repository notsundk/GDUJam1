using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Rubber : Turret
{
    public GameObject bullet;
    public override void Shoot()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        float shortestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float temp = Vector3.Distance(enemy.transform.position, spaceship.transform.position);
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if (temp < shortestDistance && distance <= range)
            {
                shortestDistance = temp;
                target = enemy;
            }
        }
        if (enemies.Length < 1)
        {
            target = null;
        }

        if (target != null)
        {
            Vector3 bv = target.transform.position - this.transform.position;
            bv.Normalize();

            float rotZ = this.transform.rotation.eulerAngles.z;
            GameObject tempBullet = Instantiate(bullet);
            tempBullet.transform.rotation = Quaternion.Euler(0, 0, rotZ + 90);
            tempBullet.transform.position = this.transform.position;
            bv *= tempBullet.GetComponent<Bullet_Rubber>().bulletSpeed;
            tempBullet.GetComponent<Rigidbody2D>().velocity = bv;
        }

    }
}
