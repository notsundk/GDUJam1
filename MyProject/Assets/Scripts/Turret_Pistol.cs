using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Pistol : Turret
{
    // Start is called before the first frame update
    public GameObject bullet;
    public override void Shoot()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        float shortestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float temp = Vector3.Distance(enemy.transform.position, spaceship.transform.position);
            if (temp < shortestDistance)
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

        }

        Vector3 bulletVelocity = Vector3.MoveTowards(this.transform.position, target.transform.position, 1);
        GameObject tempBullet = Instantiate(bullet, this.transform.position, this.transform.rotation);
        tempBullet.GetComponent<TurretBullet>().dmg = data.atk;
        tempBullet.GetComponent<Rigidbody2D>().velocity = bulletVelocity.normalized * tempBullet.GetComponent<TurretBullet>().bulletSpeed;
    }
}
