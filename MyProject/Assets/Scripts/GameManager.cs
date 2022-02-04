using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<GameObject> turrets;
    SpaceShip spaceship;
    bool gameOver = false;
    private float timer;
    public int day = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1 && spaceship == null)
        {
            spaceship = FindObjectOfType<SpaceShip>();
        }

        if(spaceship.hp <= 0 && !gameOver)
        {
            Destroy(spaceship.gameObject);
            gameOver = true;
        }

        if(gameOver)
        {
            timer += Time.deltaTime;
        }

        if(spaceship.battery >= spaceship.maxBattery)
        {
            print("you win!");
            day++;
            SceneManager.LoadScene(1);
            spaceship = FindObjectOfType<SpaceShip>();
        }

        if(timer >= 3)
        {
            gameOver = false;
            SceneManager.LoadScene(0);
        }
    }
}