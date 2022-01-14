using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData data;
    [HideInInspector] public float hp;
    [HideInInspector] public float atk;
    [HideInInspector] public float movespeed;
    private float originalMovespeed;
    [HideInInspector] public GameObject target;
    Rigidbody2D rb;

    float meleeTimer = 0;
    bool meleeUp = true;
    public float attackInterval;

    public bool stunned = false;
    private float stunTimer = 0;

    public bool slowed = false;
    private float slowTimer = 0;

    void Start()
    {
        hp = data.hp;
        atk = data.atk;
        movespeed = data.movespeed;
        target = GameObject.FindGameObjectWithTag("spaceship");
        rb = GetComponent<Rigidbody2D>();
        originalMovespeed = movespeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(!stunned)
            Attack();
        else
            stunTimer += Time.deltaTime;

        if (stunTimer > 0.25)
        {
            stunned = false;
            stunTimer = 0;
        }

        if (slowed)
        {
            movespeed = originalMovespeed / 2;
            slowTimer += Time.deltaTime;
        }
        if(slowTimer > 1)
        {
            movespeed = originalMovespeed;
            slowed = false;
            slowTimer = 0;
        }
            
            

        if (!meleeUp)
            meleeTimer+= Time.deltaTime;
        if(meleeTimer > attackInterval)
        {
            meleeUp = true;
            meleeTimer = 0;
        }

        if (hp < 0)
            Destroy(gameObject);
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
