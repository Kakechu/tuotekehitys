using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    // VARIABLES:

    // reference to Obstacle Object
    public GameObject obstacle;
    // reference to Collectible Object
    public GameObject collectible;
    // x coordinate limit to which falling objects can be spawned
    public float maxX;
    // reference to Spawn Point
    public Transform spawnPoint;
    // how often obstacles are spawned
    public float spawnRateObstacle;
    // how often collectibles are spawned
    public float spawnRateCollectible;
    //float spawnRate = 1.0f;

    bool gameStarted = false;

    // reference to "tap to start text"
    //public GameObject startText;
    // reference to score count text
    public TextMeshProUGUI scoreText;
    // variable for score
    int score = 0;
    // variable for time passed
    //float timePassed = 0f;
    // highscore
    public TextMeshProUGUI highScoreText;
    // collectible counter
    public TextMeshProUGUI collectibleScoreText;
    // menu
    public GameObject minigameMenu;

    //Minipelimenua
    private float touchArea = 0.1f;


    void Start()
    {
        highScoreText.text = "Your record: " + PlayerPrefs.GetInt("highScore", 0).ToString();

        collectibleScoreText.text = "Hearts: " + "heart count here";

       
    }


    // Update is called once per frame
    void Update()
    {
        // when screen is clicked for the first time, game starts

        //T�st� alkaa testi
        if (Input.touchCount > 0)
        {
            // Otetaan ensimm�inen kosketus
            Touch kosketus = Input.GetTouch(0);

            // Tarkista, onko kosketus liian lyhyt (klikkaus)
            if (kosketus.phase == TouchPhase.Began && kosketus.deltaTime < touchArea)
            {
                // M��rit� sormen sijainti
                Vector3 kosketusSijainti = Camera.main.ScreenToWorldPoint(kosketus.position);

                // Tarkista, onko kosketus osunut t�h�n GameObjectiin (el�imeen)
                Collider2D osuttuCollider = Physics2D.OverlapPoint(kosketusSijainti);

                if (osuttuCollider != null)
                {
                    if (osuttuCollider.CompareTag("startMinigame") && !gameStarted)
                    {
                   
                        //starts spawning falling objects
                        StartSpawning();

                        gameStarted = true;

                        //removes the menu
                        minigameMenu.SetActive(false);
                    }

                    else if (osuttuCollider.CompareTag("Back"))
                    {
                        SceneManager.LoadScene("foxView");
                    }

                }
            }
        }
    }

    // OBSTACLE SPAWNER

    private void StartSpawning()
    {
        // calls function again and again at a certain rate
        // InvokeRepeating(function name, when it starts to call function, spawnrate)
        //spawnRate = 0.3f;
        // spawnrate 
        //if (Time.time % 5 == 0)
        //{
        //    spawnRate = spawnRate * 0.5f;
        //}

        // EI TOIMI :(
        //if (timePassed > 5f)
        //{
        // make spawnRate smaller?
        //  spawnRate = 0.3f;

        // resetting the timer
        //timePassed = 0f;
        //}

        InvokeRepeating("SpawnObstacle", 0.5f, spawnRateObstacle);

        InvokeRepeating("SpawnCollectible", 1.0f, spawnRateCollectible);

    }

    private void SpawnObstacle()
    {

        // creating a spawn position
        Vector3 spawnPos = spawnPoint.position;

        // creating a random x position for spawn position
        spawnPos.x = Random.Range(-maxX, maxX);

        // instantiating the obstacle at the random spawn position
        // Instantiate(object, position, rotation)
        // default rotation = Quaternion.identity, because we don't need any external rotations
        Instantiate(obstacle, spawnPos, Quaternion.identity);

        // increments score value
        score++;
        // stores score value to scoreText (=the UI element) so it changes when needed
        scoreText.text = score.ToString();

        // highscore
        if (score > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", score);
            highScoreText.text = "Your record: " + score.ToString();
        }



    }

    private void SpawnCollectible()
    {
        // creating a spawn position
        Vector3 spawnPos = spawnPoint.position;

        // creating a random x position for spawn position
        spawnPos.x = Random.Range(-maxX, maxX);

        // instantiating the collectible at the random spawn position
        Instantiate(collectible, spawnPos, Quaternion.identity);

    }







}