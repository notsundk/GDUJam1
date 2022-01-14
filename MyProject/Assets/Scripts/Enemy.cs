using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData data;
    public int hp;
    public int atk;
    public float movespeed;
    public GameObject target;
    Rigidbody2D rb;

    float meleeTimer = 0;
    bool meleeUp = true;
    public float attackInterval;

    void Start()
    {
        hp = data.hp;
        atk = data.atk;
        movespeed = data.movespeed;
        target = GameObject.FindGameObjectWithTag("spaceship");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        if (!meleeUp)
            meleeTimer+= Time.deltaTime;
        if(meleeTimer > attackInterval)
        {
            meleeUp = true;
            meleeTimer = 0;
        }
    }

    public virtual void Attack()
    {
        Vector3 speed = Vector3.MoveTowards(this.transform.position, target.transform.position, 1).normalized;
        speed *= -movespeed;

        rb.velocity = speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject spaceship = collision.gameObject;
        if (spaceship.CompareTag("spaceship") && meleeUp)
        {
            spaceship.GetComponent<SpaceShip>().hp -= atk;
            meleeUp = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject spaceship = collision.gameObject;
        if(spaceship.CompareTag("spaceship") && meleeUp)
        {
            spaceship.GetComponent<SpaceShip>().hp -= atk;
            meleeUp = false;
        }
    }
}
