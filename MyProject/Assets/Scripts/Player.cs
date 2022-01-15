using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [HideInInspector] public Ground standingGround;
    [SerializeField] private GameObject bullet;
    public int money;
    [SerializeField] private float movespeed;
    private bool openShop = false;
    Rigidbody2D rb;

    [SerializeField] private GameObject Selector;
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject[] turretIcons;
    [SerializeField] private GameObject[] Turrets;
    private int selection = 0;
    private float shootTimer = 0;
    private bool canShoot = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        #region movement
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(movespeed, rb.velocity.y, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-movespeed, rb.velocity.y, 0);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(rb.velocity.x, -movespeed, 0);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(rb.velocity.x, movespeed, 0);
        }
        else
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);
        }
        #endregion

        #region Construct
        if(Input.GetMouseButtonDown(2))
        {
            if (!openShop)
                openShop = true;
            else
                openShop = false;
        }

        if(openShop)
        {
            Panel.SetActive(true);
            Selector.SetActive(true);
         
            if(Input.mouseScrollDelta.y > 0)
            {
                selection--;
            }
            else if(Input.mouseScrollDelta.y < 0)
            {
                selection++;
            }

            if (selection >= turretIcons.Length)
            {
                selection = 0;
            }
            if (selection < 0)
            {
                selection = turretIcons.Length - 1;
            }
            Selector.transform.position = turretIcons[selection].transform.position;

            int cost = Turrets[selection].GetComponent<Turret>().data.cost;
            if (Input.GetMouseButtonDown(1))
            {
                if(standingGround != null)
                {
                    if (!standingGround.turretOn && money >= cost)
                    {
                        money -= cost;
                        GameObject temp = Instantiate(Turrets[selection], standingGround.transform);
                        temp.GetComponent<Turret>().ground = standingGround;
                        standingGround.turretOn = true;
                    }
                }
            }
        }
        else
        {
            Panel.SetActive(false);
            Selector.SetActive(false);
        }
        #endregion

        #region Attack
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 pos = mouse - transform.position;
        float rotation = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;

        float distance = pos.magnitude;
        Vector2 direction = pos / distance;

        direction.Normalize();
        if(Input.GetMouseButton(0) && canShoot)
        {
            Vector3 bv = mouse - this.transform.position;
            bv.Normalize();

            float rotZ = rotation;
            GameObject tempBullet = Instantiate(bullet);
            tempBullet.transform.rotation = Quaternion.Euler(0, 0, rotZ + 90);
            tempBullet.transform.position = this.transform.position;
            tempBullet.GetComponent<TurretBullet>().dmg = 1;
            bv *= 5;
            tempBullet.GetComponent<Rigidbody2D>().velocity = bv;

            canShoot = false;
        }
         
        if(!canShoot)
        {
            shootTimer += Time.deltaTime;
        }
        if(shootTimer > 0.75f)
        {
            shootTimer = 0;
            canShoot = true;
        }
        #endregion
    }
}
