using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Flamethrower : Turret
{
    public GameObject bullet;
    public override void Shoot()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        float shortestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if (distance < shortestDistance && distance <= range)
            {
                shortestDistance = distance;
                target = enemy;
            }
        }
        if (enemies.Length < 1)
        {
            target = null;
        }

        if (target != null)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            if (distance <= range)
            {
                float rotZ = this.transform.rotation.eulerAngles.z;
                GameObject tempBullet = Instantiate(bullet);
                tempBullet.transform.rotation = Quaternion.Euler(0, 0, rotZ + 90);
                tempBullet.transform.position = this.transform.position;
                tempBullet.GetComponent<Turret_Flamethrower_flames>().dmg = data.atk;
                Vector3 bv = -tempBullet.transform.up;
                bv.Normalize();
                bv *= tempBullet.GetComponent<Turret_Flamethrower_flames>().bulletSpeed;
                tempBullet.GetComponent<Rigidbody2D>().velocity = bv;

                GameObject tempBullet2 = Instantiate(bullet);
                tempBullet2.transform.rotation = Quaternion.Euler(0, 0, rotZ + 90 + 10);
                tempBullet2.transform.position = this.transform.position;
                tempBullet2.GetComponent<Turret_Flamethrower_flames>().dmg = data.atk;
                Vector3 bv2 = -tempBullet2.transform.up;
                bv2.Normalize();
                bv2 *= tempBullet2.GetComponent<Turret_Flamethrower_flames>().bulletSpeed;
                tempBullet2.GetComponent<Rigidbody2D>().velocity = bv2;

                GameObject tempBullet3 = Instantiate(bullet);
                tempBullet3.transform.rotation = Quaternion.Euler(0, 0, rotZ + 90 - 10);
                tempBullet3.transform.position = this.transform.position;
                tempBullet3.GetComponent<Turret_Flamethrower_flames>().dmg = data.atk;
                Vector3 bv3 = -tempBullet3.transform.up;
                bv3.Normalize();
                bv3 *= tempBullet3.GetComponent<Turret_Flamethrower_flames>().bulletSpeed;
                tempBullet3.GetComponent<Rigidbody2D>().velocity = bv3;
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
