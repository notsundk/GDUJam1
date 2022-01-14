using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Minigun : Turret
{
    int times = 0;
    public float upTime;
    public float downTime;

    public GameObject bullet;
    public override void Shoot()
    {
        if(times < (upTime * 1/interval))
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
                tempBullet.GetComponent<TurretBullet>().dmg = data.atk;
                bv *= tempBullet.GetComponent<TurretBullet>().bulletSpeed;
                tempBullet.GetComponent<Rigidbody2D>().velocity = bv;
            }
            
        }
        else if(times >= ((upTime * 1 / interval) + (downTime * 1/interval)))
        {
            times = 0;
        }
        times++;
    }
}
