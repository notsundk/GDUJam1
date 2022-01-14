using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Sniper_Crosshair : MonoBehaviour
{
    public GameObject cross;
    public float lifeSpan;
    private float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > lifeSpan)
        {
            Destroy(gameObject);
        }
    }
}
