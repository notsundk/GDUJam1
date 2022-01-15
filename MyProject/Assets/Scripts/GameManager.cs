using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<GameObject> turrets;
    SpaceShip spaceship;
    public bool gameOver = false;
    private float timer;
    public int day = 1;
    public GameObject lose;
    public TextMeshProUGUI daySurvived;
    public TextMeshProUGUI Score;
    public 
    // Start is called before the first frame update
    void Awake()
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

      

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (spaceship.hp <= 0 && !gameOver)
            {
                //Destroy(spaceship.gameObject);
                gameOver = true;
            }

            if (gameOver)
            {
                daySurvived.text = day.ToString();
                float temp = ((day * 100) + (FindObjectOfType<Player>().money * 10));
                Score.text = temp.ToString();
                Time.timeScale = 0;
                lose.SetActive(true);
            }
        }
       
        if(spaceship.battery >= spaceship.maxBattery)
        {
            print("you win!");
            day++;
            SceneManager.LoadScene(1);
            spaceship = FindObjectOfType<SpaceShip>();
        }

        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Time.timeScale = 1.0f;
            gameOver = false;
        }
    }
}