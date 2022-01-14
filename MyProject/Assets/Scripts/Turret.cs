using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public TurretData data;
    public int hp;
    public int atk;
    public int cost;
    public float range;
    private float interval;
    protected GameObject spaceship;
    protected GameObject target = null;

    private bool shoot = true;
    private float shootTimer = 0;

    void Start()
    {
        hp = data.hp;
        atk = data.atk;
        cost = data.cost;
        range = data.cost;
        interval = data.atkInterval;
        spaceship = GameObject.FindGameObjectWithTag("spaceship");
    }
    void Update()
    {
        if(shoot)
        {
            Shoot();
            shoot = false;
        }
        else
        {
            shootTimer += Time.deltaTime;
        }

        if(shootTimer >= interval)
        {
            shootTimer = 0;
            shoot = true;
        }

        if(target != null)
        {
            Vector3 lookDir = target.transform.position - this.transform.position;
            Quaternion rot = Quaternion.LookRotation(target.transform.position);
            Vector3 rotation = rot.eulerAngles;
            this.transform.rotation = Quaternion.Euler(0, 0, rotation.z);
        }
    }
    public virtual void Shoot()
    {
        print("NORMAL");
    }
}
