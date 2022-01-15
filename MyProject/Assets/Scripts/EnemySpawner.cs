using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int selection;
    public GameObject[] enemy;
    bool spawn = true;
    float timer = 0;
    public float respawnTime;
    void Start()
    {
        respawnTime -= (0.75f * GameManager.Instance.day);
    }

    // Update is called once per frame
    void Update()
    {
        selection = Random.Range(0, enemy.Length);

        if(spawn)
        {
            Instantiate(enemy[selection], transform);
            spawn = false;
        }
        else
        {
            timer += Time.deltaTime;
        }

        if (timer >= respawnTime)
        {
            spawn = true;
            timer = 0;
        }
           
        
        
    }
}
