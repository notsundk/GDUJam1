using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Ground standingGround;
    public int money;
    [SerializeField] private float movespeed;
    private bool openShop = false;
    Rigidbody2D rb;

    [SerializeField] private GameObject Selector;
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject[] turretIcons;
    [SerializeField] private GameObject[] Turrets;
    private int selection = 0;
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
        if(Input.GetMouseButtonDown(1))
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
                selection++;
            }
            else if(Input.mouseScrollDelta.y < 0)
            {
                selection--;
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
            if (Input.GetMouseButtonDown(2))
            {
                if(standingGround != null)
                {
                    if (!standingGround.turretOn && money >= cost)
                    {
                        money -= cost;
                        Instantiate(Turrets[selection], standingGround.transform);
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
    }
}
