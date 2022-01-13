using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Ground standingGround;
    [SerializeField] private float movespeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region movement
        if(Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(movespeed * Vector2.up * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(movespeed * Vector3.down * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(movespeed * Vector2.left * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(movespeed * Vector2.right * Time.deltaTime);
        }
        #endregion
    }
}
