using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private GameObject mask;
    private bool playerOn = false;
    private GameObject player;

    void Start()
    {
        mask.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (player.GetComponent<Player>().standingGround != this)
            {
                playerOn = false;
            }
        }

        if (!playerOn)
        {
            mask.SetActive(false);
            player = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("player"))
        {
            return;
        }
        else
        {
            player = collision.gameObject;
            playerOn = true;
            mask.SetActive(true);
            player.GetComponent<Player>().standingGround = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            playerOn = false;
        }
    }
}
