using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private GameObject mask;
    private bool playerOn = false;
    private GameObject player;
    public int id = 0;

    void Start()
    {
        mask.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if (player.GetComponent<Player>().standingGround != this)
            {
                mask.SetActive(false);
                player = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            player = collision.gameObject;
            mask.SetActive(true);
            player.GetComponent<Player>().standingGround = this;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            player = collision.gameObject;
            mask.SetActive(true);
            player.GetComponent<Player>().standingGround = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            if(player != null)
            {
                player.GetComponent<Player>().standingGround = null;
                mask.SetActive(false);
                player = null;
            }
        }
    }
}
