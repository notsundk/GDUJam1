using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Bar : MonoBehaviour
{
    float health = 1.0f;
    float startHealth;
    float battery = 1.0f;
    public SpaceShip spaceship;
    [SerializeField] private RectTransform HPBar;

    [SerializeField] private RectTransform BatteryBar;
    // Start is called before the first frame update
    void Start()
    {
        spaceship = FindObjectOfType<SpaceShip>();
        startHealth = spaceship.hp;
    }

    // Update is called once per frame
    void Update()
    {
        health = (spaceship.hp / startHealth);

        battery = (spaceship.battery / spaceship.maxBattery);

        HPBar.transform.localScale = new Vector3(health, HPBar.localScale.y, 0);

        BatteryBar.transform.localScale = new Vector3(battery, BatteryBar.localScale.y, 0);
    }
}
