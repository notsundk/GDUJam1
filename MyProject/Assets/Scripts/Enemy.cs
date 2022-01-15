using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData data;
    public float hp;
    [HideInInspector] public float atk;
    [HideInInspector] public float movespeed;
    private float originalMovespeed;
    public GameObject target;
    protected Rigidbody2D rb;

    protected float attackTimer = 0;
    protected bool attackUp = true;
    public float attackInterval;

    public bool stunned = false;
    private float stunTimer = 0;

    public bool slowed = false;
    private float slowTimer = 0;
    public GameObject battery;

    float deathTimer;

    Animator anim;
    int chance;
    void Start()
    {
        hp = data.hp;
        atk = data.atk;
        movespeed = data.movespeed;
        target = GameObject.FindGameObjectWithTag("spaceship");
        rb = GetComponent<Rigidbody2D>();
        originalMovespeed = movespeed;
        anim = GetComponentInChildren<Animator>();
        chance = Random.Range(0, 100);
    }

    // Update is called once per frame
    void Update()
    {
        if(!stunned && hp > 0)
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
            
            

        if (!attackUp)
            attackTimer+= Time.deltaTime;
        if(attackTimer > attackInterval)
        {
            attackUp = true;
            attackTimer = 0;
        }

        if (hp <= 0)
        {
            anim.SetTrigger("death");

            deathTimer += Time.deltaTime;

            if(deathTimer > 0.067)
            {
                FindObjectOfType<Player>().money += data.reward;
                if (chance > 95)
                {
                    GameObject temp = Instantiate(battery);
                    temp.transform.position = transform.position;
                }
                Destroy(gameObject);
            }
            

        }
            
    }

    public virtual void Attack()
    {
        Vector3 speed = Vector3.MoveTowards(this.transform.position, target.transform.position, 1).normalized;
        speed *= -movespeed;

        rb.velocity = speed;
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject spaceship = collision.gameObject;
        if (spaceship.CompareTag("spaceship") && attackUp)
        {
            spaceship.GetComponent<SpaceShip>().hp -= atk;
            attackUp = false;
        }
    }
    protected virtual void OnCollisionStay2D(Collision2D collision)
    {
        GameObject spaceship = collision.gameObject;
        if(spaceship.CompareTag("spaceship") && attackUp)
        {
            spaceship.GetComponent<SpaceShip>().hp -= atk;
            attackUp = false;
        }
    }
}
