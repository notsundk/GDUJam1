using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public TurretData data;
    [HideInInspector] public float hp;
    [HideInInspector] public float atk;
    [HideInInspector] public int cost;
    [HideInInspector] public float range;
    protected float interval;
    protected GameObject spaceship;
    protected GameObject target = null;

    private bool shoot = true;
    private float shootTimer = 0;

    void Start()
    {
        hp = data.hp;
        atk = data.atk;
        cost = data.cost;
        range = data.range;
        interval = data.atkInterval;
        spaceship = GameObject.FindGameObjectWithTag("spaceship");
    }
    void Update()
    {
        if(shootTimer >= interval)
        {
            shootTimer = 0;
            shoot = true;
        }

        if(target != null)
        {
            Vector3 pos = target.transform.position - transform.position;
            float rotation = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;

            float distance = pos.magnitude;
            Vector2 direction = pos / distance;
            direction.Normalize();
            this.transform.rotation = Quaternion.Euler(0, 0, rotation);
        }

        if (shoot)
        {
            Shoot();
            shoot = false;
        }
        else
        {
            shootTimer += Time.deltaTime;
        }
        
    }
    public virtual void Shoot()
    {
        print("NORMAL");
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}