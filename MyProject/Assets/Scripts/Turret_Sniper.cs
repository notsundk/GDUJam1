using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Sniper : Turret
{
    public GameObject crosshair;
    public override void Shoot()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        float highestHp = 0;
        foreach (GameObject enemy in enemies)
        {
            float tempHp = enemy.GetComponent<Enemy>().hp;
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if (tempHp > highestHp && distance <= range)
            {
                highestHp = tempHp; 
                target = enemy;
            }
        }
        if (enemies.Length < 1)
        {
            target = null;
        }

        if (target != null)
        {
            GameObject tempCross;
            tempCross = Instantiate(crosshair, target.transform);
            target.GetComponent<Enemy>().hp -= atk;
        }

        
    }

}
