using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ranged : Enemy
{
    public int range;
    public GameObject bullet;
    public override void Attack()
    {
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("turret");
        float shortestDistance = Mathf.Infinity;

        if (turrets.Length <= 0)
        {
            target = GameObject.FindGameObjectWithTag("spaceship");
        }

        foreach (GameObject turret in turrets)
        {
            float distance = Vector3.Distance(turret.transform.position, transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                target = turret;
            }
        }

        float d = Vector3.Distance(target.transform.position, transform.position);
        if (d > range)
        {
            print(target.name);
            Vector3 speed = this.transform.position - target.transform.position;
            speed.Normalize();
            speed *= -movespeed;
            
            rb.velocity = speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }


        if(attackUp && d <= range)
        {
            Shoot();
            attackUp = false;
        }
        
    }
    private void Shoot()
    {
        Vector3 bv = target.transform.position - this.transform.position;
        bv.Normalize();

        float rotZ = this.transform.rotation.eulerAngles.z;
        GameObject tempBullet = Instantiate(bullet);
        tempBullet.transform.position = this.transform.position;
        bv *= tempBullet.GetComponent<EnemyBullet>().bulletSpeed;
        tempBullet.GetComponent<EnemyBullet>().dmg = atk;
        tempBullet.GetComponent<Rigidbody2D>().velocity = bv;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    protected override void OnCollisionEnter2D(Collision2D collision) { }

    protected override void OnCollisionStay2D(Collision2D collision) { }
}
